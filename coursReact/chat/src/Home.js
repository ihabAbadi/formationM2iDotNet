import React from "react"
import { Row, Input } from "antd"
import {post} from "./services/ApiService"
import {LocalService} from "./services/LocalService"
import { useHistory } from "react-router-dom"
const Home = (props) => {
    const {Search} = Input
    const history = useHistory()
    const login = (value) => {
        post("user",{name:value}).then(res=>{
            const response = res.data
            alert(response.msg)
            //LocalService.user = value
            //Utilisation du localStorage
            localStorage.setItem("user", value)
            history.push('/chat')

        })
    }
    return (
        <Row justify="center" align="middle" style={{minHeight:'100vh', backgroundColor: '#666'}}>
            <Search
                placeholder="Votre Login"
                enterButton="Se connecter"
                size="large"
                onSearch={login}
            />
        </Row>
    )
}

export default Home