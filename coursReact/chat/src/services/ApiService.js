import axios from "axios"
const url ="http://localhost:80/"
export const get = (path) => {
    return axios.get(url+path)
}

export const post = (path,data) => {
    return axios.post(url+path,data)
}