import { createContext, useReducer, useContext, Reducer } from "react";
import { HomeStore, homeActionTypes, homeInitialStore, homeReducer } from "./homeReducer";


export const HomeContext = createContext<HomeStore>(homeInitialStore);
export const HomeDispatch = createContext<React.Dispatch<homeActionTypes>>(() => { })

export const HomeDispatchProvider = ({ children }: { children: React.ReactNode }) => {
    const [store, dispatch] = useReducer
        (
            homeReducer,
            homeInitialStore,
        )
    return <HomeDispatch.Provider value={dispatch}>{children}</HomeDispatch.Provider>
}

export const HomeContextProvider = ({ children }: { children: React.ReactNode }) => {
    const [store] = useReducer(
        homeReducer,
        homeInitialStore,
    );

    return <HomeContext.Provider value={store}>{children}</HomeContext.Provider>
};

export const useHomeContext = () => useContext(HomeContext);
export const useHomeDispatch = () => useContext(HomeDispatch);