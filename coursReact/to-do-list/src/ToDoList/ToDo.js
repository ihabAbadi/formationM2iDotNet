import React, { Component } from "react"

export class ToDo extends Component {
    constructor(props) {
        super(props)
        //Dans les props, on va avoir un objet todo avec content, status
    }
    renderDoneOrUnDoneButton = () => {
        if(this.props.todo.status == 'done') {
            return(
                <button className='btn btn-success m-1'>done</button>
            )
        }
        else {
            return(
                <button className='btn btn-danger m-1'>undone</button>
            )
        }
    }
    render() {
        return(
            <div className="row">
                <div className={(this.props.todo.status == 'done') ? 'col-6 text-success' : 'col-6 text-danger'}>
                    {this.props.todo.content}
                </div>
                <div className='col-2'>
                {this.renderDoneOrUnDoneButton()}
                </div>
                <div className='col-2'>
                    <button className='btn btn-primary'>edit</button>
                </div>
                <div className='col-2'>
                    <button className='btn btn-primary'>delete</button>
                </div>
            </div>
        )
    }
}