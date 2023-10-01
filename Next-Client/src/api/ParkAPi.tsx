import axios from 'axios';
import { Game } from '../pages/ParkResult/types';

const BASE_URL = "https://localhost:7151/api/park";

// export const getDocInfo = async (setGameInfo: React.Dispatch<any>) => {
//     await axios.get(`https://localhost:7151/api/park/getDocInfo`)
//         .then((resp) => {
//             if (resp.data) {
//                 setGameInfo(resp.data);
//             }
//         }).catch((error) => {
//             console.log(error);
//         })
// }

export const getDocInfo = async () => {
    const response = await axios.get(`https://localhost:7151/api/park/getDocInfo`);
    return response.data;
}

export const getGames = async (place_ID: string) => {
    const response = await axios.get(`https://localhost:7151/api/park/getgames/${place_ID}`)
    return response.data;
}

export const createNewGame = async (body: any) => {
    const response = await axios.post(`https://localhost:7151/api/park/CreateNewGame`, { placeDetail: body.park, game: body.game });
    return response.data;
}

export const startGame = async (body: any) => {
    const game = body.game
    const response = await axios.post(`https://localhost:7151/api/park/startGame`, game);
    return response.data;
}