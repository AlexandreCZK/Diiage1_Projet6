<template>
  <div class="container borderCol">
    <div class="row">
      <!--BoardPlayer-->
      <div class="col-10 row-room">
        <br />
        <div class="container">
          <div class="row">
            <div class="col-2">
              <button
                type="button"
                class="btn btn-block door"
                id="door-left"
                v-if="filterDoors('left')"
                @click="nextRoom()"
              >
                Porte de gauche
              </button>
            </div>

            <div class="col-8">
              <div class="row" id="r1">
                <button
                  type="button"
                  class="btn btn-block door"
                  v-if="filterDoors('front')"
                  @click="nextRoom()"
                >
                  Porte de devant
                </button>
              </div>
              <div class="row">
                <template v-for="monster in this.room.monsters">
                <button
                  class="card"
                  style="width: 30%"
                  id="cardMonster"
                  v-if="!(monster.currentLife <= 0)"
                  @click="selectAMonster(monster)"
                  v-bind:key="monster.id"
                >
                  <img
                    class="card-img-top"
                    src="../assets/necromancian.jpg"
                    alt="Card image cap"
                    v-if="monster.className == 'Necromancian'"
                  />
                  <img
                    class="card-img-top"
                    src="../assets/gobelin.jpg"
                    alt="Card image cap"
                    v-else-if="monster.className == 'Gobelin'"
                  />
                  <img
                    class="card-img-top"
                    src="../assets/orc.jpg"
                    alt="Card image cap"
                    v-else-if="monster.className == 'Orc'"
                  />
                  <div class="card-body">
                    <h5 class="card-title">{{ monster.className }}</h5>
                  </div>
                  <div class="progress">
                    <div
                      class="progress-bar bg-danger"
                      role="progressbar"
                      style="width: 50%"
                      v-bind:style="{ width: purcentageLife(monster) }"
                      aria-valuenow="25"
                      aria-valuemin="0"
                      aria-valuemax="100"
                    >
                      {{ purcentageLife(monster) }}
                    </div>
                  </div>
                </button>
                </template>
              </div>

              <div class="row" id="r2" v-if="this.room.treasure.length > 0">
                <button type="button" class="btn-treasure" style="width: 20%">
                  <img
                    class="card-img-top"
                    src="../assets/treasure.png"
                    alt="Card image cap"
                  />
                </button>
              </div>
            </div>

            <div class="col-2">
              <button
                type="button"
                class="btn btn-block door"
                id="door-right"
                v-if="filterDoors('right')"
                @click="nextRoom()"
              >
                Porte de droite
              </button>
            </div>
          </div>
        </div>
      </div>
      <div class="col-2 borderCol">Dungeon Log</div>
    </div>
    <div class="row"><!--Life--></div>
    <div class="row">
      <!--iconeSkill-->
      <div class="col-10 life" style="padding-bottom: 1%; padding-top: 1%">
        <div class="progress">
          <div
            class="progress-bar bg-danger"
            role="progressbar"
            v-bind:style="{ width: purcentageLife(this.character) }"
            aria-valuenow="25"
            aria-valuemin="0"
            aria-valuemax="100"
          >
            LIFE {{ purcentageLife(this.character) }}
          </div>
        </div>
      </div>
      <div class="col-1"></div>
    </div>

    <div class="row">
      <!--iconeSkill-->
      <template v-for="skill in this.character.skills">
        <div class="col" v-bind:key="skill.id" v-if="skill.isEnable">
          Skill {{ skill.locationSkills }}
        </div>
      </template>
      <div class="col"><!--au dessus de potion--></div>
      <div class="col">Potions</div>
      <div class="col"><!--au dessus de Leavue dungeon--></div>
    </div>

    <div class="row">
      <!--iconeSkill-->
      <template v-for="skill in this.character.skills">
        <div
          class="col spellDesign"
          v-if="skill.isEnable && skill.locationSkills == 1"
          v-bind:key="skill.id"
        >
          <button type="button" class="btn-spell" @click="selectASkill(skill)">
            <img
              class="card-img-top"
              src="../assets/SpellWizzard/1.jpg"
              alt="Card image cap"
            />
            <!-- 
            <img
              class="card-img-top"
              src="../assets/SpellWarrior/1.jpg"
              alt="Card image cap"
            />
            <img
              class="card-img-top"
              src="../assets/SpellShaman/1.jpg"
              alt="Card image cap"
            />*-->
          </button>
        </div>
        <div
          class="col spellDesign"
          v-if="skill.isEnable && skill.locationSkills == 2"
          v-bind:key="skill.id"
        >
          <button type="button" class="btn-spell">
            <img
              class="card-img-top"
              src="../assets/SpellWizzard/2.jpg"
              alt="Card image cap"
            />
            <!-- 
            <img
              class="card-img-top"
              src="../assets/SpellWarrior/2.jpg"
              alt="Card image cap"
            />
            <img
              class="card-img-top"
              src="../assets/SpellShaman/2.jpg"
              alt="Card image cap"
            />-->
          </button>
        </div>
        <div
          class="col spellDesign"
          v-if="skill.isEnable && skill.locationSkills == 3"
          v-bind:key="skill.id"
        >
          <button type="button" class="btn-spell">
            <img
              class="card-img-top"
              src="../assets/SpellWizzard/3.jpg"
              alt="Card image cap"
            />
            <!--
            <img
              class="card-img-top"
              src="../assets/SpellWarrior/3.jpg"
              alt="Card image cap"
            />
            <img
              class="card-img-top"
              src="../assets/SpellShaman/3.jpg"
              alt="Card image cap"
            />
          --></button>
        </div>
      </template>
      <div class="col">
        <button type="button" class="btn btn-warning">Next Turn</button>
      </div>

      <div class="col spellDesign">
        <button type="button" class="btn-spell" style="width: 50%">
          <div class="container-spell">
            <img
              class="card-img-top"
              src="../assets/potion.jpg"
              alt="Card image cap"
            />
            <div class="bottom-left">{{ this.character.items.length }}</div>
          </div>
        </button>
      </div>

      <div class="col">
        <button type="button" class="btn btn-danger" @click="leave()">
          Leave Dungeon
        </button>
      </div>
    </div>
  </div>
</template>
 
<script>
import api from "../services/api";
export default {
  name: "singlePlayerGame",
  data() {
    return {
      gameId: null,
      room: {},
      character: {},
      nbRoom: 0,
      selectedSkill: null,
      selectedPerso: null,
    };
  },
  mounted: function () {
    api.gameApi.getRoom(this.$route.query.idGame, this.nbRoom).then((res) => {
      this.room = res;
      this.room.doors = res.doors.$values;
      this.room.monsters = res.monsters.$values;
      if (res.treasure != undefined) {
        this.room.treasure = res.treasure.$values;
      }
      api.gameApi.getAGame(this.$route.query.idGame).then((res) => {
        this.gameId = res.gameId;
        this.character = res.character;
        this.character.items = res.character.items.$values;
        this.character.skills = res.character.skills.$values;
      });
    });
  },
  methods: {
    filterDoors(door) {
      return this.room.doors.includes(door);
    },
    purcentageLife(perso) {
      var res = (perso.currentLife * 100) / perso.maxLife;
      return res.toFixed(2).toString() + "%";
    },
    leave() {
      this.$router.push({ name: "Account" });
    },
    selectASkill(skill) {
      if (this.selectedSkill != null) {
        this.selectedSkill = null;
      } else {
        this.selectedSkill = skill;
      }
      this.attack();
    },
    selectAMonster(perso) {
      if (this.selectedPerso != null) {
        this.selectedPerso = null;
      } else {
        this.selectedPerso = perso;
      }
      this.attack();
    },
    attack() {
      if (this.selectedSkill != null) {
        if (this.selectedPerso != null) {
          var res = confirm(
            "You are going to attack " +
              this.selectedPerso.className +
              " with the skill " +
              this.selectedSkill.locationSkills +
              " are you sur"
          );
          if (!res) {
            return;
          }
          api.actionApi
            .useSkill(
              this.gameId,
              this.nbRoom,
              this.character.id,
              this.selectedPerso.id,
              this.selectedSkill.locationSkills - 1
            )
            .then((res) => {
              this.room.monsters = res.monsters.$values;
              this.selectedPerso = null;
              this.selectedSkill = null;
            });
        }
      }
    },
    nextRoom() {
      var result = true;
      this.room.monsters.forEach(monster => {
        if (monster.currentLife > 0) {
          result = false;
        }
      });
      if (result) {
        this.nbRoom++;
        api.gameApi
          .getRoom(this.$route.query.idGame, this.nbRoom)
          .then((res) => {
            this.room = res;
            this.room.doors = res.doors.$values;
            this.room.monsters = res.monsters.$values;
            if (res.treasure != undefined) {
              this.room.treasure = res.treasure.$values;
            }
            api.gameApi.getAGame(this.$route.query.idGame).then((res) => {
              this.gameId = res.gameId;
              this.character = res.character;
              this.character.items = res.character.items.$values;
              this.character.skills = res.character.skills.$values;
            });
          });
      }
      else{
        alert("Kill all monster before !!");
      }
    },
  },
};
</script>

<style>
.col-10 {
  color: white;
  border: solid;
}
.life {
  border: none;
}

.progress {
  height: 100px;
}

.btn-spell {
  border: solid;
  border-radius: 5%;
  color: rgb(0, 26, 47);
  width: 50%;

  -webkit-transition: all 1s ease; /* Safari et Chrome */
  -moz-transition: all 1s ease; /* Firefox */
  -ms-transition: all 1s ease; /* Internet Explorer 9 */
  -o-transition: all 1s ease; /* Opera */
  transition: all 1s ease;
}

.btn-spell:hover {
  -webkit-transform: scale(1.1); /* Safari et Chrome */
  -moz-transform: scale(1.1); /* Firefox */
  -ms-transform: scale(1.1); /* Internet Explorer 9 */
  -o-transform: scale(1.1); /* Opera */
  transform: scale(1.1);
}

.spellDesign {
  padding-top: 1%;
  padding-bottom: 1%;
}

.container {
  position: relative;
  text-align: center;
  color: white;
}

.container-spell {
  position: relative;
  text-align: center;
  color: white;
}

.bottom-left {
  position: absolute;
  bottom: 1%;
  left: 1%;
  color: white;
}

.borderCol {
  border: solid;
  border-color: rgb(255, 255, 255);
}

.row-room {
  background-image: url("../assets/room2.jpg");
  background-size: cover;
}

#r1 {
  padding-bottom: 5%;
  border: white;
}

#r2 {
  padding-top: 5%;
  border: white;
}

#cardMonster {
  margin: 1%;
  color: rgb(255, 255, 255);
  background-color: rgb(53, 0, 0);
  border: 2px solid rgb(0, 0, 0);
}

.door {
  background-color: black !important;
  color: white !important;
  border: 2px solid #623800 !important;
  border-radius: 0px !important;
}

.door:hover {
  background-color: rgb(0, 0, 0) !important;
  color: rgb(255, 255, 255) !important;
  border: 2px solid #000000 !important;
}

#door-right {
  height: 95%;
  padding-left: 0%;
  padding-right: 0%;
}

#door-left {
  height: 95%;
  padding-left: 0%;
  padding-right: 0%;
}

.card-img-top-treasure {
  background-color: white;
}

.btn-treasure {
  width: 100%;
}
.btn-treasure:hover {
  animation: shake 0.5s;

  /* When the animation is finished, start again */
  animation-iteration-count: infinite;
}
@keyframes shake {
  0% {
    transform: translate(1px, 1px) rotate(0deg);
  }
  10% {
    transform: translate(-1px, -2px) rotate(-1deg);
  }
  20% {
    transform: translate(-3px, 0px) rotate(1deg);
  }
  30% {
    transform: translate(3px, 2px) rotate(0deg);
  }
  40% {
    transform: translate(1px, -1px) rotate(1deg);
  }
  50% {
    transform: translate(-1px, 2px) rotate(-1deg);
  }
  60% {
    transform: translate(-3px, 1px) rotate(0deg);
  }
  70% {
    transform: translate(3px, 1px) rotate(-1deg);
  }
  80% {
    transform: translate(-1px, -1px) rotate(1deg);
  }
  90% {
    transform: translate(1px, 2px) rotate(0deg);
  }
  100% {
    transform: translate(1px, -2px) rotate(-1deg);
  }
}

.card-img-top {
  padding-bottom: 5%;
}
</style>