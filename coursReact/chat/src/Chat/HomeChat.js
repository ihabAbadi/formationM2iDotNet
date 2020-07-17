import React, { useState, useEffect } from "react"
import { useHistory } from "react-router-dom"
import { LocalService } from "../services/LocalService"
import Channels from "./Channels"
const HomeChat = (props) => {
    const [load, setLoad] = useState(true)
    const history = useHistory()
    useEffect(() => {
        if (LocalService.user == undefined) {
            history.push('/')
        }
    }, [load])
    return (
        <div>
            <Channels></Channels>
        </div>
    )
}

export default HomeChat