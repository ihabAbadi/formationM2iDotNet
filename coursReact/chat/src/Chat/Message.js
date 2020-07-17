import React from "react"
import {Row, Col} from "antd"
const Message = (props) => {
    return(
        <Row justify='start' align='bottom'>
            <Col span={24}>
                <Row>
                    <Col>{props.message.user}</Col>
                </Row>
                <Row>
                    <Col>{props.message.content}</Col>
                </Row>
            </Col>
        </Row>
    )
}

export default Message