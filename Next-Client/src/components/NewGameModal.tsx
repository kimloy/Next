import React, { useState, useRef, useEffect } from 'react';
import { v4 as uuidv4 } from 'uuid';
import {
    IonButtons,
    IonButton,
    IonModal,
    IonHeader,
    IonContent,
    IonToolbar,
    IonTitle,
    IonPage,
    IonItem,
    IonLabel,
    IonInput,
    IonList,
    IonSelect,
    IonSelectOption,
    IonDatetimeButton,
    IonDatetime,
    IonLoading,
} from '@ionic/react';
import {
    DatetimeChangeEventDetail,
    InputChangeEventDetail,
    IonDatetimeCustomEvent,
    IonInputCustomEvent,
    IonSelectCustomEvent,
    SelectChangeEventDetail
} from '@ionic/core';
import { createNewGame, getDocInfo } from '../api/ParkAPi';
import { Game, GameDoc } from '../pages/ParkResult/types';
import { QueryClient, useMutation, useQuery, useQueryClient } from 'react-query';


interface NewGameModalProps {
    modal: React.RefObject<HTMLIonModalElement>
    parkDetail: any;
    queryClient: QueryClient;
}

const NewGameModal: React.FC<NewGameModalProps> = ({ modal, parkDetail, queryClient }) => {
    const [userGameName, setUserGameName] = useState<string>("");
    const [userGame, setUserGame] = useState<string>("");
    const [numberOfPlayers, setNumberOfPlayers] = useState<number>(0);
    const [scheduleDate, setScheduleDate] = useState<string>("");
    const [scheduleTime, setScheduleTIme] = useState<string>("");
    const [gameDoc, setGameDoc] = useState<GameDoc>({ gameDocId: 0, sports_List: [] })

    const QueryGameDoc = useQueryClient();

    const { isLoading, isError, isSuccess, data } = useQuery<GameDoc>("gameDoc", getDocInfo)

    const onGameNameChange = (ev: IonInputCustomEvent<InputChangeEventDetail>) => {
        if (ev.target.value) {
            const text = ev.target.value as string;
            setUserGameName(text);
        }
    }

    const onGameSelect = (ev: IonSelectCustomEvent<SelectChangeEventDetail>) => {
        setUserGame(ev.detail.value);
    }

    const onNumberOfPlayersInput = (ev: IonInputCustomEvent<InputChangeEventDetail>) => {
        if (ev.target.value) {
            const currNum = ev.target.value;
            setNumberOfPlayers(currNum as number);
        }
    }

    const onDateTimeChange = (ev: IonDatetimeCustomEvent<DatetimeChangeEventDetail>) => {
        console.log(`event target value: `, { ev })
        const eventValue = ev.detail.value as string;
        const dateTime = eventValue.split("T");

        setScheduleDate(dateTime[0])
        setScheduleTIme(dateTime[1]);
    }

    const confirm = () => {
        const gameID = uuidv4();
        const newGame: Game = {
            game_ID: gameID,
            place_ID: parkDetail.result.place_Id,
            player_ID: "1",
            sport_Name: userGame,
            name: userGameName,
            number_Of_Players: numberOfPlayers,
            DateTime: `${scheduleDate}T${scheduleTime}`,
            active: false,
        }
        mutation.mutate({ game: newGame, park: parkDetail });
    }

    const mutation = useMutation(createNewGame, {
        onSuccess: () => {
            queryClient.invalidateQueries('GetGames')
            modal.current?.dismiss();
        }
    });

    return (
        <IonModal ref={modal} trigger="open-modal" onWillDismiss={() => modal.current?.dismiss()}>
            {isLoading && (
                <IonLoading message="Loading" />
            )}
            {isSuccess && (
                <>
                    <IonHeader>
                        <IonToolbar>
                            <IonButtons slot="start">
                                <IonButton onClick={() => modal.current?.dismiss()}>Cancel</IonButton>
                            </IonButtons>
                            <IonTitle>Create a New Game</IonTitle>
                            <IonButtons slot="end">
                                <IonButton strong={true} onClick={() => confirm()}>
                                    Confirm
                                </IonButton>
                            </IonButtons>
                        </IonToolbar>
                    </IonHeader>
                    <IonContent className="ion-padding">
                        <IonList>
                            <IonItem>
                                <IonInput
                                    label="Game Name"
                                    labelPlacement="stacked"
                                    onIonChange={(ev) => onGameNameChange(ev)}
                                />
                            </IonItem>
                            <IonItem>
                                <IonSelect label="Game" labelPlacement="stacked" onIonChange={(ev) => onGameSelect(ev)}>
                                    {data.sports_List.map((sport, index) => {
                                        return (
                                            <IonSelectOption key={index} value={sport.name}>{sport.name}</IonSelectOption>
                                        )
                                    })}
                                </IonSelect>
                            </IonItem>
                            <IonItem>
                                <IonInput
                                    label="Number of Players:"
                                    type="number" placeholder="0"
                                    labelPlacement='stacked'
                                    onIonInput={(ev) => onNumberOfPlayersInput(ev)}></IonInput>
                            </IonItem>
                            <IonItem>
                                <IonDatetimeButton datetime="datetime"></IonDatetimeButton>

                                <IonModal keepContentsMounted={true}>
                                    <IonDatetime id="datetime" onIonChange={(ev) => onDateTimeChange(ev)}></IonDatetime>
                                </IonModal>
                            </IonItem>
                        </IonList>
                    </IonContent>
                </>
            )}
        </IonModal>
    )
}

export default NewGameModal;

