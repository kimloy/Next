import axios from 'axios';


export const getNearbyParks = async (lat: number, lng: number, setPlaygroundList: React.Dispatch<React.SetStateAction<google.maps.places.PlaceResult[]>>) => {
    await axios.get(`https://localhost:7151/api/places/nearby/${lat}/${lng}`)
        .then(resp => {
            setPlaygroundList(resp.data.results);
        })
        .catch(error => console.log(error));
}

export const getParkDetails = async (place_id: string, setParkDetail: React.Dispatch<any>) => {
    await axios.get(`https://localhost:7151/api/places/detail/${place_id}`).then((resp) => {
        if (resp.data.result) {
            setParkDetail(resp.data);
        }
    }).catch((error) => console.log(error));
}

export const getGelocation = async (zipCode: string, setLatitude: React.Dispatch<React.SetStateAction<number>>, setLongitude: React.Dispatch<React.SetStateAction<number>>) => {
    await axios.get(`https://localhost:7151/api/places/geocoding/${zipCode}`)
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
