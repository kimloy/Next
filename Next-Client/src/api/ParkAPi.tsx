import axios from 'axios';

const BASE_URL = "https://localhost:7247/api/park";

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
    const response = await axios.get(`https://localhost:7247/api/park/getDocInfo`, {
        withCredentials: true, headers: {
            'X-CSRF': '1'
        }
    });
    return response.data;
}

export const getGames = async (place_ID: string) => {
    const response = await axios.get(`https://localhost:7247/api/park/getgames/${place_ID}`, {
        withCredentials: true, headers: {
            'X-CSRF': '1'
        }
    })
    return response.data;
}

export const createNewGame = async (body: any) => {
    const response = await axios.post(`https://localhost:7247/api/park/CreateNewGame`, { placeDetail: body.park, game: body.game }, {
        withCredentials: true, headers: {
            'X-CSRF': '1'
        }
    });
    return response.data;
}

export const startGame = async (body: any) => {
    const game = body.game
    const response = await axios.post(`https://localhost:7247/api/park/startGame`, game, {
        withCredentials: true, headers: {
            'X-CSRF': '1'
        }
    });
    return response.data;
}

