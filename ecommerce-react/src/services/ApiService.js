import axios from "axios"

const url = "http://localhost:61692/api/"
export const getProducts = () => {
    return axios.get(url+'Product')
}

export const getProduct = (id) => {
    return axios.get(url+'Product/'+id)
}