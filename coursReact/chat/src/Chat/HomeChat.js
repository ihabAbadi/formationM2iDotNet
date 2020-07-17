import React, { useState, useEffect } from "react"
import { useHistory } from "react-router-dom"
import { LocalService } from "../services/LocalService"
import Channels from "./Channels"
import { get } from "../services/ApiService"
import Messages from "./Messages"
import { Layout } from "antd"
const HomeChat = (props) => {
    
    const [load, setLoad] = useState(true)
    const [messages, setMessages] = useState([])
    const history = useHistory()
    
    
    const getMessages = (channel) => {
        get('message/'+channel).then(res=>{
            setMessages(res.data)
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
            <Messages messages={messages}></Messages>
        </Layout>
    )
}

export default HomeChat