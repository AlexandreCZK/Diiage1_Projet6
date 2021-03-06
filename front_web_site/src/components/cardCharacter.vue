<template>
  <div class="col-lg-6 col-md-6 mb-4" v-bind:id="character.id">
    <div class="card h-100">
      <img
        class="card-img-top"
        :src="this.picture"
        :alt="character.className"
      />
      <div class="card-body">
        <h4 class="card-title">
          <label class="text-dark">{{ character.name }}</label>
        </h4>
        <p class="card-text text-dark">Level : {{ character.level }}</p>
        <div class="edit">
          <input placeholder="New name" />
          <div class="btn btn-primary" @click="edit(character.id)">Ok</div>
          <div class="btn btn-primary mt-3" @click="editSkills(character.id)">
            Edit Skills
          </div>
        </div>
        <div class="card-footer" v-if="!isPlay">
          <div
            class="float-left btn btn-danger"
            @click="supprimer(character.id)"
          >
            Supprimer
          </div>
          <div class="float-right btn btn-secondary" @click="startEdit()">
            Edit
          </div>
        </div>
        <div class="card-footer" v-else>
          <div
            class="d-block btn btn-danger"
            @click="jouer()"
          >
            Jouer
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import api from "../services/api";
export default {
  data() {
    return {
      picture: "",
    };
  },
  props: {
    character: {
      type: Object,
      required: true,
    },
    isPlay: {
      type: Boolean,
      required: true,
    },
    isMultiplayer: {
      type: Boolean,
      required: false,
    },
  },
  mounted() {
    let pictureChar;
    switch (this.character.className) {
      case "Warrior":
        pictureChar = require("@/assets/warrior.jpg");
        break;
      case "Shaman":
        pictureChar = require("@/assets/shaman.jpg");
        break;
      case "Wizard":
        pictureChar = require("@/assets/wizzard2.jpg");
        break;
    }
    this.picture = pictureChar;
    document
      .getElementById(this.character.id)
      .getElementsByClassName("edit")[0].style.display = "none";
  },
  methods: {
    startEdit() {
      let div = document
        .getElementById(this.character.id)
        .getElementsByClassName("edit")[0];
      if (div.style.display == "") {
        div.style.display = "none";
      } else {
        div.style.display = "";
      }
    },

    supprimer(id) {
      var res = confirm("Are you sure you want to delete ?");
      if (!res) {
        return;
      }
      api.characterApi.delete(id).then((result) => {
        if (result) {
          alert("Character is delete");
          document.location.reload();
        }
      });
    },

    edit(id) {
      let name = document
        .getElementById(this.character.id)
        .getElementsByClassName("edit")[0]
        .getElementsByTagName("input")[0].value;
      let data = { Id: id, Name: name };

      api.characterApi.edit(data).then((result) => {
        this.character = result;
        document
          .getElementById(this.character.id)
          .getElementsByClassName("edit")[0]
          .getElementsByTagName("input")[0].value = "";
        this.startEdit();
      });
    },

    editSkills(id) {
      this.$router.push({ name: "ModifySkills", query: { id: id } });
    },

    jouer() {
      api.gameApi.createAGame(this.isMultiplayer, this.character.id)
      .then((res) => {
        this.$router.push({ name: "SinglePlayerGame", query: { idGame: res.gameId }});
      });
    },
  },
};
</script>
<style scoped>
img {
  width: 100%;
  margin: 0 auto;
}
</style>