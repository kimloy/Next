import { IonButton, IonCol, IonContent, IonGrid, IonHeader, IonPage, IonRow, IonSearchbar, IonTitle, IonToolbar, SearchbarInputEventDetail } from '@ionic/react';
import MapsContainer from '../../components/MapsContainer';
import { HomeContext, HomeContextProvider, HomeDispatch, HomeDispatchProvider, useHomeContext, useHomeDispatch } from "./context/HomeContext";
import { Device } from '@capacitor/device';
import './Home.css';
import { useEffect, useReducer, useState } from 'react';
import ParksList from '../../components/ParksList';
import { homeInitialStore, homeReducer } from './context/homeReducer';

const Home: React.FC = () => {
  const [gameSearch, setGameSearch] = useState<string>("");
  const [userZipCode, setUserZipCode] = useState<string>("");
  const [renderMap, setRenderMap] = useState<boolean>(false);
  const [reloadMap, setReloadMap] = useState<boolean>(false);

  const [homeStore, dispatch] = useReducer(
    homeReducer,
    homeInitialStore
  );

  const handleSearchInput = (ev: Event, searchBar: string) => {
    let query = '';
    const target = ev.target as HTMLIonSearchbarElement;
    if (target) query = target.value!.toLowerCase();

    if (searchBar === "game") setGameSearch(query);
    else if (searchBar === "zipCode") setUserZipCode(query);
  }

  const logDeviceInfo = async () => {
    const info = await Device.getInfo();

    if (info) {
      dispatch({
        type: "SET_OS",
        value: {
          operatingSystem: info.operatingSystem,
        }
      })
    }
  };

  const handleSearchClick = () => {
    setReloadMap(!reloadMap);
    setRenderMap(true);
  };

  const handleSearchBarEnterPress = (ev: React.KeyboardEvent<HTMLIonSearchbarElement>) => {
    if (ev.code === "Enter") {
      setReloadMap(!reloadMap);
      setRenderMap(true);
    }
  }

  useEffect(() => {
    logDeviceInfo()
  }, []);

  // useEffect(() => {
  //   dispatch({ type: "SET_DISPATCH", value: dispatch });
  // }, [dispatch]);

  return (
    <HomeDispatch.Provider value={dispatch}>
      <HomeContext.Provider value={homeStore}>
        <IonPage>
          <IonHeader>
            <IonToolbar>
              <IonTitle>Home</IonTitle>
            </IonToolbar>
          </IonHeader>
          <IonContent fullscreen>
            <IonHeader collapse="condense">
              <IonToolbar>
                {/* <IonTitle size="large">Tab 1</IonTitle> */}
                <IonSearchbar
                  placeholder="Custom Placeholder"
                  value={userZipCode}
                  onKeyUp={(ev) => handleSearchBarEnterPress(ev)}
                  onIonInput={(ev) => handleSearchInput(ev, "zipCode")}
                />
              </IonToolbar>
            </IonHeader>
            {homeStore.operatingSystem === "windows" && (
              <IonGrid>
                <IonRow>
                  <IonCol offset-sm="1">
                    <IonSearchbar
                      class="gameSearchbar"
                      placeholder="Game"
                      value={gameSearch}
                      debounce={1000}
                      onIonInput={(ev) => handleSearchInput(ev, "game")}
                    />
                  </IonCol>
                  <IonCol>
                    <IonSearchbar
                      class="zipCodeSearchBar"
                      placeholder="Zip Code"
                      value={userZipCode}
                      onIonInput={(ev) => handleSearchInput(ev, "zipCode")}
                    />
                  </IonCol>
                  <IonCol>
                    <IonButton onClick={handleSearchClick}>Search</IonButton>
                  </IonCol>
                </IonRow>
                <IonRow >
                  <IonCol>
                    {renderMap && <MapsContainer userZipCode={userZipCode} reloadMap={reloadMap} />}
                  </IonCol>
                  <IonCol>
                    <ParksList />
                  </IonCol>
                </IonRow>
              </IonGrid>
            )}
            {homeStore.operatingSystem === "ios" && (
              <>
                {renderMap && <MapsContainer userZipCode={userZipCode} reloadMap={reloadMap} />}
                {homeStore.playgroundList.length > 0 && <ParksList />}
              </>

            )}
          </IonContent>
        </IonPage>
      </HomeContext.Provider>
    </HomeDispatch.Provider>
  );
};

export default Home;
