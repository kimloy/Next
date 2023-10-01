
export interface HomeStore {
    userZipCode: string;
    playgroundList: google.maps.places.PlaceResult[];
    infoWindowIndex: number;
    operatingSystem: string;
}

export interface ActionTypeSetUserZipCode {
    type: "SET_USER_ZIP_CODE",
    value: {
        userZipCode: string
    };
}

export interface ActionTypeClearPlaygroundList {
    type: "CLEAR_PLAYGROUND_LIST",
    value: {
        playgroundList: google.maps.places.PlaceResult[],
    }
}

export interface ActionTypeSetDispatch {
    type: "SET_DISPATCH";
    value: React.Dispatch<homeActionTypes>;
};

export interface ActionTypeSetPlaygroundList {
    type: "SET_PLAYGROUND_LIST",
    value: {
        playgroundList: google.maps.places.PlaceResult[],
    };
};

export interface ActionTypeSetInfoWindowIndex {
    type: "SET_INFOWINDOW_INDEX",
    value: {
        infoWindowIndex: number,
    }
}

export interface ActionTypeSetOS {
    type: "SET_OS",
    value: {
        operatingSystem: string,
    }
}

export type homeActionTypes =
    | ActionTypeSetUserZipCode
    | ActionTypeSetPlaygroundList
    | ActionTypeSetDispatch
    | ActionTypeClearPlaygroundList
    | ActionTypeSetInfoWindowIndex
    | ActionTypeSetOS



export const homeInitialStore = {
    userZipCode: "",
    homeDispatch: () => { },
    playgroundList: [],
    infoWindowIndex: -1,
    operatingSystem: "",
} as HomeStore

export const homeReducer = (store: HomeStore, action: homeActionTypes) => {
    switch (action.type) {
        case "SET_USER_ZIP_CODE":
            return {
                ...store,
                userZipCode: action.value.userZipCode,
            };
        case "SET_PLAYGROUND_LIST":
            return {
                ...store,
                playgroundList: action.value.playgroundList
            };
        case "CLEAR_PLAYGROUND_LIST":
            return {
                ...store,
                playgroundList: action.value.playgroundList
            }
        case "SET_OS":
            return {
                ...store,
                operatingSystem: action.value.operatingSystem
            }

        case "SET_DISPATCH":
            return {
                ...store,
                homeDispatch: action.value
            }

        case "SET_INFOWINDOW_INDEX":
            return {
                ...store,
                infoWindowIndex: action.value.infoWindowIndex
            }
        default:
            throw Error();
    }
}