import React from "react"
import { Layout, Row, Input } from "antd"
import Message from "./Message"
const { Content } = Layout
const {Search} = Input
const Messages = (props) => {

    return (
        <Content style={{ minHeight: '100vh' }}>
            {props.messages.map((element, index) => (
                <Message message={element} key={index}></Message>
            ))}
            <Row>
                <Search
                    placeholder="nouveau message"
                    enterButton="Envoyer"
                    size="middle"
                    onSearch={props.addMessage}
                />
            </Row>
        </Content>
    )
}

export default Messages