import React, { Component } from "react"
import { FormToDo } from "./FormToDo"
import { NotificationToDo } from "./NotificationToDo"
import { ToDo } from "./ToDo"


export class ListToDos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            todos : []
        }
    }

    addToDo = (text) =>{
        //... => opérateur spread qui permet de recuperer la totalité des éléments du tableau
        let tmpTodos = [...this.state.todos]
        let newTodo = {
            id : (this.state.todos[this.state.todos.length-1] != undefined) ? (this.state.todos[this.state.todos.length-1].id+1) : 1,
            status : 'undone',
            content : text
        }
        tmpTodos.push(newTodo)
        this.setState({
            todos : tmpTodos
        })
    }

    deleteToDo = (id) => {
        let tmpTodos = []
        for(let todo of this.state.todos) {
            if(todo.id != id){
                tmpTodos.push(todo)
            }
            
        }
        this.setState({
            todos : tmpTodos
        })
    }

    changeStatus = (id, newStatus) => {
        let tmpTodos = []
        for(let todo of this.state.todos) {
            if(todo.id == id){
                todo.status = newStatus
            }
            tmpTodos.push(todo)
        }
        this.setState({
            todos : tmpTodos
        })
    }

    editToDo = (id, newContent) => {
        let tmpTodos = []
        for(let todo of this.state.todos) {
            if(todo.id == id){
                todo.content = newContent
            }
            tmpTodos.push(todo)
        }
        this.setState({
            todos : tmpTodos
        })
    }

    render() {
        return(
            <div className="container">
                <h1 className="text-center">React ToDo List</h1>
                <FormToDo addToDo={this.addToDo}></FormToDo>
                <NotificationToDo numberTask={this.state.todos.length}></NotificationToDo>
                {this.state.todos.map(todo => {
                    return(
                        <ToDo editToDo={this.editToDo} deleteToDo={this.deleteToDo} changeStatus={this.changeStatus} todo={todo}></ToDo>
                    )
                })}
            </div>
        )
    }
}