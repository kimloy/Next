import axios from 'axios';

const BASE_URL = "https://localhost:7151/api/players";

export const getPlayer = async (player_ID: string) => {
    var response = await axios.get(`${BASE_URL}/getPlayer/${player_ID}`);
    return response.data;
}