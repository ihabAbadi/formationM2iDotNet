import React, { useState, useEffect } from "react"
import { useHistory } from "react-router-dom"
import { LocalService } from "../services/LocalService"
import Channels from "./Channels"
import { get, post } from "../services/ApiService"
import Messages from "./Messages"
import { Layout } from "antd"
const HomeChat = (props) => {

    const [load, setLoad] = useState(true)
    const [messages, setMessages] = useState([])
    const history = useHistory()
    const [currentChannel, setCurrentChannel] = useState(undefined)

    const ws = new WebSocket('ws://localhost:3010')

    const getMessages = (channel) => {
        setCurrentChannel(channel)
        get('message/' + channel).then(res => {
            setMessages(res.data)
        })
    }

    const addMessage = (message) => {
        const sendMessage = { content: message, channel: currentChannel, user: localStorage.getItem('user') }
        post('message', sendMessage).then(res => {
            // const tmpMessages = [...messages, sendMessage]
            // setMessages(tmpMessages)
            ws.send(JSON.stringify(sendMessage))
        })
    }
    ws.onopen = () => {
        console.log('connected to webSocket server')
    }
    ws.onmessage = (evt) => {
        const message = JSON.parse(evt.data)
        console.log(message)
        if (message.channel == currentChannel) {
            const tmpMessages = [...messages, message]
            setMessages(tmpMessages)
        }
    }

    useEffect(() => {
        //if (LocalService.user == undefined) {
        //Version avec localStorage
        if(localStorage.getItem("user") == undefined) {
        history.push('/')
        }
    }, [load])


    return (
        <Layout>
            <Channels getMessages={getMessages}></Channels>
            <Messages addMessage={addMessage} messages={messages}></Messages>
        </Layout>
    )
}

export default HomeChat