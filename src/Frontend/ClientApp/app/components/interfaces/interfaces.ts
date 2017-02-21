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

export interface Match {
    TimeStampUtc: Date;
    Points: number;
    PlayerList: string[];
    MatchResult: MatchResult;
    Won: boolean;
}

export interface MatchResult {
    Team1Score: number;
    Team2Score: number;
    Team1Won: boolean;
}

export interface PartnerResult {
    Username: string;
    UsersNormalWinrate: number;
    Matches: number;
    Wins: number;
}

export interface Player {
    GravatarEmail: string;
}