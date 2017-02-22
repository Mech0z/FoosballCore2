import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Match } from '../interfaces/interfaces';
import { MatchResult } from '../interfaces/interfaces';
import { PartnerResult } from '../interfaces/interfaces';

@inject(HttpClient)
export class Player {
    public email: string;
    public recentMatches: Match[];
    public partnerResults: PartnerResult[];
    public http: HttpClient;

    constructor(http: HttpClient) {
        this.http = http;
    }

    activate(routingParam: string) {
        this.email = routingParam.email;

        this.http.fetch('http://staging-foosball9000api.sovs.net/api/player/GetPlayerMatches?email=' + this.email)
            .then(result => result.json() as Promise<Match[]>)
            .then(data => {
                this.recentMatches = data.slice(0, 10);

                this.CalculateWon();
            })

        this.http.fetch('http://staging-foosball9000api.sovs.net/api/player/GetPlayerPartnerResults?email=' + this.email)
            .then(result => result.json() as Promise<PartnerResult[]>)
            .then(data => {
                this.partnerResults = data;
            })
    }

    CalculateWon() {
        this.recentMatches.forEach(match => {
            var partOfTeam1 = false;
            if (match.PlayerList[0] == this.email || match.PlayerList[1] == this.email) {
                partOfTeam1 = true;
            }

            match.Won = (partOfTeam1 && match.MatchResult.Team1Won) || (!partOfTeam1 && !match.MatchResult.Team1Won);
        });
    }


}