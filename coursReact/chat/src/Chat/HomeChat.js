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
    
    
    const getMessages = (channel) => {
        setCurrentChannel(channel)
        get('message/'+channel).then(res=>{
            setMessages(res.data)
        })
    }

    const addMessage = (message) => {
        const sendMessage = {content : message, channel: currentChannel, user:LocalService.user}
        post('message', sendMessage).then(res=>{
            const tmpMessages = [...messages, sendMessage]
            setMessages(tmpMessages)
        })
    }

    useEffect(() => {
        if (LocalService.user == undefined) {
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