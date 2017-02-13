var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
let Player = class Player {
    constructor(http) {
        this.http = http;
    }
    activate(routingParam) {
        this.email = routingParam.email;
        this.http.fetch('http://staging-foosball9000api.sovs.net/api/player/GetPlayerMatches?email=' + this.email)
            .then(result => result.json())
            .then(data => {
            this.recentMatches = data.slice(0, 10);
            this.CalculateWon();
        });
        this.http.fetch('http://staging-foosball9000api.sovs.net/api/player/GetPlayerPartnerResults?email=' + this.email)
            .then(result => result.json())
            .then(data => {
            this.partnerResults = data;
        });
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
};
Player = __decorate([
    inject(HttpClient),
    __metadata("design:paramtypes", [HttpClient])
], Player);
export { Player };
//# sourceMappingURL=Player.js.map