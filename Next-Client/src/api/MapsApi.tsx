import axios from 'axios';

const BASE_URL = "https://localhost:7247/api/places";

const config = {
    withCredentials: true, headers: {
        'X-CSRF': '1'
    }
}

export const getNearbyParks = async (lat: number, lng: number, setPlaygroundList: React.Dispatch<React.SetStateAction<google.maps.places.PlaceResult[]>>) => {
    await axios.get(`${BASE_URL}/nearby/${lat}/${lng}`, config)
        .then(resp => {
            setPlaygroundList(resp.data.results);
        })
        .catch(error => console.log(error));
}

export const getParkDetails = async (place_id: string, setParkDetail: React.Dispatch<any>) => {
    await axios.get(`${BASE_URL}/detail/${place_id}`, config).then((resp) => {
        if (resp.data.result) {
            setParkDetail(resp.data);
        }
    }).catch((error) => console.log(error));
}

export const getGelocation = async (zipCode: string, setLatitude: React.Dispatch<React.SetStateAction<number>>, setLongitude: React.Dispatch<React.SetStateAction<number>>) => {
    await axios.get(`${BASE_URL}/geocoding/${zipCode}`, config)
        .then(resp => {
            if (resp.data.results[0].geometry.location) {
                const lat = resp.data.results[0].geometry.location.lat;
                const lng = resp.data.results[0].geometry.location.lng;
                setLatitude(lat);
                setLongitude(lng);
            }
        })
        .catch(error => console.log(error));
}

export const getParksPhoto = async (photo_ref: string) => {

}
