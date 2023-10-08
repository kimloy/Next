export interface Game {
    game_ID: string,
    sport_Name: string,
    place_ID: string,
    player_ID: string,
    name: string,
    number_Of_Players: number,
    DateTime: string,
    active: boolean,
    players?: [],
    game_Master?: string,
}

export interface GameDoc {
    gameDocId: number,
    sports_List: sports_List[],
}

export interface sports_List {
    sport_ID: string,
    name: string,
    max_Num_Players: string
}