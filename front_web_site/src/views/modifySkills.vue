<template>
  <div>
    <h1 class="text-light">Manage Skills</h1>
    <div class="table-responsive text-center">
      <table class="table text-light">
        <tbody>
          <tr>
            <th scope="row" colspan="2">Nom de compétences</th>
            <th colspan="2">Nb tour de préparation</th>
            <th colspan="2">Dommages</th>
            <th colspan="2">Niveau pour le débloquer</th>
            <th colspan="2">Cible</th>
            <th colspan="2">Emplacement de compétences</th>
            <th colspan="2">Active</th>
          </tr>
          <tr v-for="skill in character.skills" :key="skill.id">
            <th scope="row" colspan="2">{{ skill.name }}</th>
            <th colspan="2">{{ skill.nbTurnToPrepare }}</th>
            <th colspan="2">{{ skill.coefDamages }}</th>
            <th colspan="2">{{ skill.levelToUnlock }}</th>
            <th colspan="2">{{ skill.target }}</th>
            <th colspan="2">{{ skill.locationSkills }}</th>
            <th colspan="2">
              <input
                class="form-check-input"
                type="checkbox"
                v-bind:id="'skill' + skill.id"
                v-bind:checked="skill.isEnable"
                v-bind:disabled="skill.levelToUnlock > character.level"
                @click="vue(skill)"
              />
            </th>
          </tr>
        </tbody>
      </table>
      <button class="btn btn-secondary float-left" @click="edit()">Edit</button>
    </div>
  </div>
</template>
<script>
import api from "../services/api";
export default {
  name: "modifySkills",
  data() {
    return {
      character: {
        skills: [],
      },
    };
  },
  created() {
    api.characterApi
      .get(this.$route.query.id)
      .then((result) => {
        this.character = result;
        this.character.skills = this.character.skills.$values;
      });
  },
  methods: {
    vue(skill) {
      let a = this.character.skills.filter(
        (s) => s.locationSkills == skill.locationSkills
      );
      a.forEach((element) => {
        if (element.id == skill.id) {
          skill.isEnable = true;
          document.getElementById("skill" + skill.id).checked = true;
        } else {
          element.isEnable = false;
        }
      });
    },
    edit() {
      api.characterApi
        .editSkill(this.character)
        .then((result) => {
          if (result) {
            this.$router.push({ name: "Account" });
          }
        });
    },
  },
};
</script>
<style scoped>
input:disabled {
  cursor: not-allowed;
}
</style>