import axios from "axios"

const url = "http://localhost:61692/api/"
export const getProducts = () => {
    return axios.get(url+'Product',{headers:{
        "Access-Control-Allow-Origin" : "*",
        "Authorization" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJpaGFiQHV0b3Bpb3MubmV0IiwiZXhwIjoxNjAxNjQ2ODU5LCJpc3MiOiJtMmkiLCJhdWQiOiJtMmkifQ.pGex5my1Tk05mWJ9Tmfs30OvhT-CXqPAXhYqd7nPCiQ"
    }})
}

export const getProduct = (id) => {
    return axios.get(url+'Product/'+id)
}