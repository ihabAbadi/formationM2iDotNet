import React, { useState, useEffect } from "react"
import { get, post } from "../services/ApiService"
import { Layout, Row, Col, Input } from "antd"
import { LocalService } from "../services/LocalService"
const { Sider } = Layout

const { Search } = Input

const Channels = (props) => {
    const [loading, setLoading] = useState(true)
    const [channels, setChannels] = useState([])

    useEffect(() => {
        get("channels").then(res => {
            setChannels(res.data)
        })
    }, [loading])

    const addChannel = (value) => {
        post('channel', {name:value, user: LocalService.user}).then(res=>{
            const response = res.data
            alert(response.msg)
            setLoading(!loading)
        })
    }
    return (
        <Layout>
            <Sider style={{ backgroundColor: '#666', color: 'white', minHeight: '100vh' }}>
                <Row justify="space-around">Channels</Row>
                {channels.map((element, index) => (
                    <Row justify="space-around" key={index}>
                        <Col style={{ color: '#fefefe' }}>#{element.name}</Col>
                    </Row>
                ))}
                <Row>
                    <Search
                        placeholder="nouveau channel"
                        enterButton="Ajouter"
                        size="large"
                        onSearch={addChannel}
                    />
                </Row>
            </Sider>
        </Layout>
    )
}

export default Channels