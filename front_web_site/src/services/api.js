import path from 'path';
import axios from 'axios';
import errorHandling from "../services/errors";
class Api {
    getUrl() {
        switch (process.env.NODE_ENV) {
            case "development":
                return "http://10.4.103.254:44357/"; // IP FOR DEV API
                //return "https://localhost:5001/"; // IP FOR LOCAL API
            case "test":
                return "";
            case "production":
                return "https://dungeon-crawler-g3-api.azurewebsites.net/";
        }
    }
    getAxiosWithToken(axios) {
        let token = document.cookie
            .split('; ')
            .find(row => row.startsWith('token='))
            .split('=')[1];
        axios.defaults.headers.common = { Authorization: `Bearer ${token}` };
        axios.defaults.baseURL = this.getUrl();
    }
}

class CharacterApi extends Api {
    getPath() {
        return "Characters";
    }
    async get(id = null) {
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        if (id === null) {
            let apiPath = path.join(
                this.getPath()
            )
            return await axios.get(apiPath)
                .then((result) => {
                    return result.data.$values;
                }).catch((err) => {
                    errorHandling.alertError(err);
                    throw err;
                });
        }
        else {
            let apiPath = path.join(
                this.getPath(),
                id.toString()
            )
            return await axios.get(apiPath)
                .then((result) => {
                    return result.data;
                }).catch((err) => {
                    errorHandling.alertError(err);
                    throw err;
                });
        }

    }

    async create(characterData) {
        let apiPath = path.join(
            this.getPath()
        )
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .post(apiPath, characterData)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async edit(characterData) {
        let apiPath = path.join(
            this.getPath()
        )
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .patch(apiPath, characterData)
            .then((result) => {
                return result.data;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async delete(id) {
        let apiPath = path.join(
            this.getPath(),
            id.toString()
        )
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .delete(apiPath)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async editSkill(characterData) {
        let apiPath = path.join(
            this.getPath()
        )
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios.put(apiPath, characterData)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }
}

class GameApi extends Api {
    getPath() {
        return "Games";
    }

    async getAGame(id) {
        let apiPath = path.join(
            this.getPath(),
            id.toString()
        );
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios.get(apiPath)
            .then((result) => {
                return result.data;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async createAGame(isMultiplayer, characterId) {
        let apiPath = path.join(
            this.getPath()
        );
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        if (isMultiplayer) {
            errorHandling.alertCustomError(500, "MultiPlayer is Not implemented");
            throw "erreur";
        }
        else {
            let characterData = {
                "Character": {
                    "Id": characterId
                }
            };
            return await axios.post(apiPath, characterData)
                .then((result) => {
                    return result.data;
                })
                .catch((err) => {
                    errorHandling.alertError(err);
                    throw err;
                });
        }
    }

    async getRoom(idGame, nbRoom) {
        let apiPath = path.join(
            this.getPath(),
            idGame.toString(),
            "Rooms",
            nbRoom.toString()
        );
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios.get(apiPath)
            .then((result) => {
                return result.data;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }
}

class ActionApi extends Api {
    getPath() {
        return "Action";
    }

    async useSkill(gameId, nbRoom, launcherId, targetId, nbSkill){
        
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        let data = {
            "GameId": gameId,
            "NbRoom": nbRoom,
            "LauncherId": launcherId,
            "TargetId": targetId,
            "NbSkill": nbSkill
        }
        let apiPath = path.join(
            this.getPath(),
            "Skill"
        );
        return await axios.post(apiPath, data).then((result) => {
            return result.data;
        })
        .catch((err) => {
            errorHandling.alertError(err);
            throw err;
        });
    }
}

class FriendApi extends Api {
    getPath() {
        return "UserFriends";
    }

    async get(id = null) {
        this.getAxiosWithToken(axios);
        if (id === null) {
            let apiPath = path.join(
                this.getPath()
            )
            axios.defaults.baseURL = this.getUrl();
            return await axios.get(apiPath)
                .then((result) => {
                    return result.data.$values;
                }).catch((err) => {
                    errorHandling.alertError(err);
                    throw err;
                });
        }
        else {
            let apiPath = path.join(
                this.getPath(),
                id.toString()
            )
            axios.defaults.baseURL = this.getUrl();
            return await axios.get(apiPath)
                .then((result) => {
                    return result.data;
                }).catch((err) => {
                    errorHandling.alertError(err);
                    throw err;
                });
        }

    }

    async create(friendData) {
        let apiPath = path.join(
            this.getPath()
        );
        axios.defaults.baseURL = this.getUrl();
        this.getAxiosWithToken(axios);
        return await axios.post(apiPath, friendData)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async delete(id) {
        let apiPath = path.join(
            this.getPath(),
            id.toString()
        );
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .delete(apiPath)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }
}

class AuthApi extends Api {
    getPath() {
        return "Auth"
    }

    async login(mail, password) {
        let apiPath = path.join(
            this.getPath(),
            "Login"
        )
        let params = new URLSearchParams();
        params.append("grant_type", "password");
        params.append("username", mail);
        params.append("password", password);
        let config = {
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
        };
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .post(apiPath, params, config)
            .then((result) => {
                return result.data.access_token;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });

    }

    async signUp(mail, firstName, lastName, birthDate, password, confirmPassword) {
        let apiPath = path.join(
            this.getPath(),
            "Signup"
        )
        let data = new FormData();
        data.append("Mail", mail);
        data.append("FirstName", firstName);
        data.append("LastName", lastName);
        data.append("BirthDate", birthDate);
        data.append("Password", password);
        data.append("ConfirmPasssword", confirmPassword);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .post(apiPath, data)
            .then(() => {
                return true
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async resetPassword(mail, password, newPassword) {
        let apiPath = path.join(
            this.getPath(),
            "ResetPassword"
        )
        let data = new FormData();
        data.append("Mail", mail);
        data.append("Password", password);
        data.append("NewPassword", newPassword);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .post(apiPath, data)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }

    async signOut() {
        let apiPath = path.join(
            this.getPath(),
            "SignOut"
        );
        this.getAxiosWithToken(axios);
        axios.defaults.baseURL = this.getUrl();
        return await axios
            .post(apiPath)
            .then(() => {
                return true;
            })
            .catch((err) => {
                errorHandling.alertError(err);
                throw err;
            });
    }
}

class ApiManager {
    constructor() {
        this.characterApi = new CharacterApi();
        this.authApi = new AuthApi();
        this.gameApi = new GameApi();
        this.userFriendApi = new FriendApi();
        this.actionApi = new ActionApi();
    }
}
export default new ApiManager();