import axios from "axios"
import { prepareOrder } from "./CartService"

const url = "http://localhost:61692/api/"
export const getProducts = () => {
    return axios.get(url+'Product',{headers:{
        "Access-Control-Allow-Origin" : "*",
        "Authorization" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJpaGFiQHV0b3Bpb3MubmV0IiwiZXhwIjoxNjAxNjQ2ODU5LCJpc3MiOiJtMmkiLCJhdWQiOiJtMmkifQ.pGex5my1Tk05mWJ9Tmfs30OvhT-CXqPAXhYqd7nPCiQ"
    }})
}

export const getProduct = (id) => {
    return axios.get(url+'Product/'+id, {headers:{
        "Access-Control-Allow-Origin" : "*",
        "Authorization" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJpaGFiQHV0b3Bpb3MubmV0IiwiZXhwIjoxNjAxNjQ2ODU5LCJpc3MiOiJtMmkiLCJhdWQiOiJtMmkifQ.pGex5my1Tk05mWJ9Tmfs30OvhT-CXqPAXhYqd7nPCiQ"
    }})
}

export const testToken = () => {
    return axios.get(url+'user/testToken', {headers:{
        "Access-Control-Allow-Origin" : "*",
        "Authorization" : "Bearer "+localStorage.getItem("token")
    }})
}

export const confirmOrder =() =>{
    return axios.post(url+'order', prepareOrder(), {headers:{
        "Access-Control-Allow-Origin" : "*",
        "Authorization" : "Bearer "+localStorage.getItem("token")
    }})
}

export const login = (user) => {
    return axios.post(url+'user/login', {...user}, {headers:{
        "content-type" : "application/json",
    }})
}