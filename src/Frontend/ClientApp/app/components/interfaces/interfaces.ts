export interface LeaderboardView {
    SeasonName: string;
    Timestamp: string;
    Entries: Array<LeaderboardViewEntry>;
}

export interface LeaderboardViewEntry{
    EloRating: number;
    Form: string;
    NumberOfGames: number;
    Wins: number;
    Losses: number;
    UserName: string;
}