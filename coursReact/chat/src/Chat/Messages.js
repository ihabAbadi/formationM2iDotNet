import React from "react"
import { Layout, Row } from "antd"
import Message from "./Message"
const { Content } = Layout
const Messages = (props) => {

    return (
        <Content style={{ minHeight: '100vh' }}>
            {props.messages.map((element, index) => (
                <Message message={element} key={index}></Message>
            ))}
        </Content>
    )
}

export default Messages