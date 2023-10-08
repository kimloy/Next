import React, { useEffect, useRef, useState } from "react";
import { getParkDetails } from "../../api/MapsApi";
import { useParams } from 'react-router';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay, Keyboard, Pagination, Scrollbar, Zoom } from 'swiper/modules';

import {
    IonButton,
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
    IonCol,
    IonContent,
    IonFab,
    IonFabButton,
    IonGrid,
    IonHeader,
    IonIcon,
    IonLabel,
    IonPage,
    IonRow,
    IonSegment,
    IonSegmentButton,
    IonText,
    IonToolbar,
    SegmentCustomEvent,
    SegmentChangeEventDetail
} from "@ionic/react";
import { add, radioButtonOnOutline } from "ionicons/icons";
import { convertTime12to24 } from "./helperFunctions";

import 'swiper/css';
import 'swiper/css/autoplay';
import 'swiper/css/keyboard';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';
import 'swiper/css/zoom';
import '@ionic/react/css/ionic-swiper.css';
import "./ParkResultContainer.css";
import NewGameModal from "../../components/NewGameModal";
import { getGames, startGame } from "../../api/ParkAPi";
import { useMutation, useQuery, useQueryClient } from "react-query";
import { Game } from "./types";
import { getPlayer } from "../../api/PlayerAPI";

const ParkResultContainer: React.FC = () => {
    const [parkDetail, setParkDetail] = useState<any>(null);
    const [ActiveOrQueue, setActiveOrQueue] = useState<string>("Active")
    const [isOpen, setIsOpen] = useState<boolean>(false);
    const modal = useRef<HTMLIonModalElement>(null);

    const { id } = useParams<{ id: string }>();

    const queryClient = useQueryClient()

    const {
        isLoading: game_Loading,
        isError: game_Error,
        isSuccess: game_Success,
        data: game_data
    } = useQuery<Game[]>(["GetGames", parkDetail], async () => {

        if (parkDetail && parkDetail.result.place_Id) {
            return await getGames(parkDetail.result.place_Id)
        }
    })

    const { isLoading, isError, isSuccess, data } = useQuery(["GetPlayer"], async () => {
        if (game_data) {
            return await getPlayer("1");
        }
    })

    const mutation = useMutation(startGame, {
        onSuccess: () => {
            queryClient.invalidateQueries("GetGames");
        }
    })

    useEffect(() => {
        if (id) {
            getParkDetails(id, setParkDetail);
        }
    }, [id]);

    console.log({ game_data })

    useEffect(() => {
        if (parkDetail != null) {
            const currDateTime = new Date();
            const day = currDateTime.getDay();

            const open = parseInt(parkDetail.result.opening_Hours.periods[day].open.time);
            const close = parseInt(parkDetail.result.opening_Hours.periods[day].close.time);
            const currTime = currDateTime.toLocaleTimeString();
            const militaryTime = parseInt(convertTime12to24(currTime));

            if (militaryTime >= open && militaryTime <= close) {
                setIsOpen(true)
            }
        }
    }, [parkDetail])

    const onSegmentChange = (e: SegmentCustomEvent) => {
        const value = e.detail.value
        if (value) {
            setActiveOrQueue(value as string)
        }
    }

    const onStartClick = (game: Game) => {
        mutation.mutate({ game });
    }

    const renderGame = (game: Game, index: number) => {
        return (
            <IonCard key={index}>
                <IonCardHeader>
                    <IonCardTitle>{game.name}</IonCardTitle>
                    <IonCardSubtitle>{game.sport_Name}</IonCardSubtitle>
                </IonCardHeader>
                <IonCardContent>
                    {`Creator: ${game.game_Master}`}<br />
                    {`Players: ${game.players?.length}/${game.number_Of_Players}`}
                </IonCardContent>
                <IonButton fill="clear" color="success" onClick={() => onStartClick(game)}>Start Game</IonButton>
                <IonButton fill="clear">Join</IonButton>
                <IonButton fill="clear">Details</IonButton>
            </IonCard>

        )
    }

    console.log({ game_data })

    return (
        <>
            <IonPage>
                <IonHeader>
                    <IonToolbar>
                        <IonSegment value={ActiveOrQueue} onIonChange={onSegmentChange}>
                            <IonSegmentButton value="Active">
                                <IonLabel>Active Games</IonLabel>
                            </IonSegmentButton>
                            <IonSegmentButton value="Queue">
                                <IonLabel>Queue</IonLabel>
                            </IonSegmentButton>
                        </IonSegment>
                    </IonToolbar>
                </IonHeader>
                <IonContent fullscreen >
                    {parkDetail && parkDetail.result && game_Success && (
                        <div>
                            <IonGrid>
                                <IonRow>
                                    <IonCol size="10" style={{ display: "flex", alignItems: "center", justifyContent: "center", hieght: "100%" }}>
                                        <IonText color={"primary"}>
                                            <h1 style={{ paddingBottom: ".5rem" }}>{parkDetail.result.name}</h1>
                                        </IonText>
                                    </IonCol>
                                    <IonCol size="2" style={{ display: "flex", alignItems: "center", justifyContent: "center", hieght: "100%" }}>
                                        <IonIcon
                                            icon={radioButtonOnOutline}
                                            color={isOpen === true ? "success" : "danger"} />
                                    </IonCol>
                                </IonRow>

                                <IonRow>
                                    <IonCol>
                                        {game_data.map((game: Game, index: number) => {
                                            if (ActiveOrQueue === "Active" && game.active === true) {
                                                return (
                                                    renderGame(game, index)
                                                )
                                            }
                                            else if (ActiveOrQueue === "Queue" && game.active === false) {
                                                return (
                                                    renderGame(game, index)
                                                )
                                            }
                                        })}
                                    </IonCol>
                                </IonRow>
                            </IonGrid>
                        </div>
                    )}
                </IonContent>
                <IonFab slot="fixed" vertical="bottom" horizontal="end">
                    <IonFabButton id="open-modal">
                        <IonIcon icon={add}></IonIcon>
                    </IonFabButton>
                </IonFab>
                <NewGameModal modal={modal} parkDetail={parkDetail} queryClient={queryClient} />
            </IonPage>

            {/* <Swiper
                modules={[Autoplay, Keyboard, Pagination, Scrollbar, Zoom]}
                autoplay={true}
                keyboard={true}
                pagination={true}
                scrollbar={true}
                zoom={true}
                slidesPerView={2}
            >
                {parkDetail && parkDetail.photos.length > 0 && (
                    parkDetail.photos.map((photo: any, index: number) => {
                        return (
                            <SwiperSlide key={index}>
                                <IonImg src={`https://maps.googleapis.com/maps/api/place/photo?maxwidth=300&photoreference=${photo.photo_reference}&key=${API_KEY}`} />
                            </SwiperSlide>

                        )
                    })
                )}

            </Swiper> */}
        </>
    )
}

export default ParkResultContainer