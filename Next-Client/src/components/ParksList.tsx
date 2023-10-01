import React, { useEffect, useState } from 'react';
import { IonButton, IonInfiniteScroll, IonInfiniteScrollContent, IonItem, IonLabel, IonList } from '@ionic/react';
import { useHomeContext, useHomeDispatch } from '../pages/Home/context/HomeContext';


const ParksList: React.FC = () => {
    const { playgroundList, infoWindowIndex, operatingSystem } = useHomeContext();
    const [scrollList, setScrollList] = useState<google.maps.places.PlaceResult[]>([]);
    const homeDispatch = useHomeDispatch();

    const generateParks = () => {
        const newParks: google.maps.places.PlaceResult[] = [];
        if (scrollList.length != playgroundList.length) {
            for (let i = scrollList.length; i < scrollList.length + 5; i++) {
                newParks.push(playgroundList[i]);
            }
            setScrollList([...scrollList, ...newParks]);
        }
    }

    const clearScrollList = () => {
        setScrollList([]);
    }

    useEffect(() => {
        clearScrollList();
        // if (scrollList.length === 0 && scrollIndex === 0) {
        //     generateParks();
        // }
    }, [playgroundList]);

    useEffect(() => {
        generateParks();
    }, [])

    const handleParkClick = (index: number) => {
        homeDispatch({
            type: "SET_INFOWINDOW_INDEX",
            value: {
                infoWindowIndex: index,
            }
        })
    }

    const containerStyle = operatingSystem === "ios" ? { marginTop: "2rem" } : { display: "block" }

    return (
        <div style={containerStyle}>
            <IonList>
                {playgroundList.map((park: google.maps.places.PlaceResult, index) => {
                    const textColor = infoWindowIndex === index ? { color: "white" } : { color: "black" };
                    if (park) {
                        return (
                            <IonItem button
                                key={index}
                                color={infoWindowIndex === index ? "primary" : ""}
                                slot={"end"}
                                onClick={() => handleParkClick(index)}
                            >
                                <IonLabel>
                                    <h3>{park.name}</h3>
                                    <p style={textColor}>Current games: 0</p>
                                </IonLabel>
                                {infoWindowIndex === index && <IonButton color={"success"} href={`/park-result/${park.place_id}`}>Open</IonButton>}
                            </IonItem>
                        );
                    }
                })}
            </IonList>
            {operatingSystem === "ios" && (
                <IonInfiniteScroll
                    onIonInfinite={(ev) => {
                        generateParks();
                        setTimeout(() => ev.target.complete(), 100);
                    }}
                    threshold="15%"
                >
                    <IonInfiniteScrollContent loadingText="Please wait..." loadingSpinner="bubbles"></IonInfiniteScrollContent>
                </IonInfiniteScroll>
            )}
        </div>
    )
}

export default ParksList;