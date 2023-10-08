import { useJsApiLoader, GoogleMap, Marker, Libraries, InfoWindow, MarkerF, InfoWindowF } from "@react-google-maps/api";
import "./MapsContainer.css";
import { HomeContext, HomeDispatch, useHomeContext, useHomeDispatch } from "../pages/Home/context/HomeContext"
import { useCallback, useEffect, useMemo, useRef, useState, useContext } from 'react';
import { getGelocation, getNearbyParks } from "../api/MapsApi";
import axios from "axios";

interface MyMapProps {
    userZipCode: string;
    reloadMap: boolean;
}

const libraries: Libraries = ["places"]

const MyMap: React.FC<MyMapProps> = ({ userZipCode, reloadMap }) => {
    const [jsxMap, setJsxMap] = useState<JSX.Element | null>(null);
    const [gMap, setGMap] = useState<google.maps.Map | null>(null);
    const [longitude, setLongitude] = useState<number>(0);
    const [latitude, setLatitude] = useState<number>(0);
    const [playgroundList, setPlaygroundList] = useState<google.maps.places.PlaceResult[]>([]);
    const API_KEY = "AIzaSyAQcKtmEs77shISr0T4UmZlFxtUdGxFODs";

    const { isLoaded } = useJsApiLoader({ googleMapsApiKey: API_KEY, libraries });

    const homeContext = useHomeContext();
    const homeDispatch = useHomeDispatch();

    const { infoWindowIndex, operatingSystem } = homeContext

    const mapStyle = operatingSystem === "ios" ?
        { width: "90%", height: "50%", margin: "auto", marginTop: "1rem", marginBotton: "1rem" }
        : { width: "100%", height: "100%" }

    const clearPlaygroundList = () => {
        homeDispatch({
            type: "CLEAR_PLAYGROUND_LIST",
            value: {
                playgroundList: []
            },
        })
    }


    const updatePlaygroundContextState = () => {
        homeDispatch({
            type: "SET_PLAYGROUND_LIST",
            value: {
                playgroundList: playgroundList
            }
        })

        homeDispatch({
            type: "SET_USER_ZIP_CODE",
            value: {
                userZipCode: userZipCode
            }
        })
    };

    useEffect(() => {
        setPlaygroundList([]);
        clearPlaygroundList();
    }, [reloadMap])

    useEffect(() => {
        getNearbyParks(latitude, longitude, setPlaygroundList);
    }, [latitude, longitude]);

    useEffect(() => {
        if (playgroundList.length > 0) {
            updatePlaygroundContextState();
        }
    }, [playgroundList]);

    useEffect(() => {
        if (infoWindowIndex != -1) closeInfoWindow();

        clearPlaygroundList();
        getGelocation(userZipCode, setLatitude, setLongitude);
    }, [reloadMap, gMap]);

    const handleInfoWindowHandler = (index: number) => {
        homeDispatch({
            type: "SET_INFOWINDOW_INDEX",
            value: {
                infoWindowIndex: index
            },
        })
        // const newLat = playgroundList[index].geometry?.location?.lat as any;
        // const newLng = playgroundList[index].geometry?.location?.lng as any;
        // setLatitude(newLat);
        // setLongitude(newLng)
    }

    const closeInfoWindow = () => {
        homeDispatch({
            type: "SET_INFOWINDOW_INDEX",
            value: {
                infoWindowIndex: -1
            },
        })
    }

    console.log({ playgroundList })

    const renderMap = () => {
        return (
            <GoogleMap
                center={{ lat: latitude, lng: longitude }}
                zoom={13}
                mapContainerStyle={{ width: "100%", height: "100%" }}
                onLoad={(map) => onMapLoad(map)}
            >
                {playgroundList.map((park: any, index: number) => {
                    const lng = park.geometry!.location?.lng;
                    const lat = park.geometry!.location?.lat;


                    if (lat && lng) {
                        return (
                            <Marker
                                key={index}
                                position={{ lat: lat, lng: lng }}
                                onClick={() => handleInfoWindowHandler(index)}
                            >
                                {infoWindowIndex === index && (
                                    <InfoWindowF onCloseClick={() => closeInfoWindow()}>
                                        <span>{park.name}</span>
                                    </InfoWindowF>
                                )}
                            </Marker>
                        );
                    }
                })}
            </GoogleMap>
        )
    };

    const getMap = useMemo(() => {
        let map = renderMap();
        setJsxMap(map);
    }, [reloadMap, infoWindowIndex, latitude, longitude, playgroundList]);

    const onMapLoad = (map: google.maps.Map) => {
        setGMap(map);
    }

    return (
        <div style={mapStyle}>
            {isLoaded && jsxMap}
        </div>
    )
}

export default MyMap;