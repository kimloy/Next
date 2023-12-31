import { IonButton, IonButtons, IonCol, IonContent, IonGrid, IonHeader, IonPage, IonRow, IonSearchbar, IonTitle, IonToolbar, SearchbarInputEventDetail } from '@ionic/react';
import MapsContainer from '../../components/MapsContainer';
import { HomeContext, HomeContextProvider, HomeDispatch, HomeDispatchProvider, useHomeContext, useHomeDispatch } from "./context/HomeContext";
import { Device } from '@capacitor/device';
import './Home.css';
import { useEffect, useReducer, useState } from 'react';
import ParksList from '../../components/ParksList';
import { homeInitialStore, homeReducer } from './context/homeReducer';
import useClaims from '../../hooks/useClaims';

const Home: React.FC = () => {
  const [gameSearch, setGameSearch] = useState<string>("");
  const [userZipCode, setUserZipCode] = useState<string>("");
  const [renderMap, setRenderMap] = useState<boolean>(false);
  const [reloadMap, setReloadMap] = useState<boolean>(false);
  const [enable, setEnable] = useState<boolean>(false);

  const { data: claims, isLoading } = useClaims(enable);
  let logoutUrl = claims?.find((claim: { type: string; }) => claim.type === 'bff:logout_url')
  let nameDict = claims?.find((claim: { type: string; }) => claim.type === 'name') || claims?.find((claim: { type: string; }) => claim.type === 'sub');
  let username = nameDict?.value;

  const [homeStore, dispatch] = useReducer(
    homeReducer,
    homeInitialStore
  );

  useEffect(() => {
    if (isLoading === false) {
      console.log({ claims });
    }
  }, [isLoading])

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

  const handleLoginClick = () => {
    setEnable(true)

  }

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
              <IonButtons slot="end">
                <IonButton
                  fill="solid"
                  href="https://localhost:7247/bff/login?returnUrl=http://localhost:8100/home"
                >
                  Login
                </IonButton>
              </IonButtons>
            </IonToolbar>
          </IonHeader>
          <IonContent fullscreen>
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
                <IonSearchbar
                  placeholder="Custom Placeholder"
                  value={userZipCode}
                  onKeyUp={(ev) => handleSearchBarEnterPress(ev)}
                  onIonInput={(ev) => handleSearchInput(ev, "zipCode")}
                />
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
