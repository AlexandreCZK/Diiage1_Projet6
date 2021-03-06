<template>
  <div>
    <h1 class="text-light text-center">Characters Creation</h1>
    <form class="pt-5">
      <div class="form-group">
        <label class="text-light">Characters Name: </label>
        <input
          type="text"
          id="name"
          v-model="character.name"
          placeholder="ex : Jean"
        />
      </div>
      <div class="form-group">
        <label class="text-light">Characters Class: </label>
        <select
          name="class"
          id="class-select"
          v-model="character.class"
          @change="changeSelect($event)"
        >
          <option selected value="">--Please choose an option--</option>
          <option value="Warrior">Warrior</option>
          <option value="Shaman">Shaman</option>
          <option value="Wizard">Wizard</option>
        </select>
      </div>
      <skills-character
        v-if="this.classChoose != ''"
        :classChoose="this.classChoose"
        :key="this.classChoose"
      ></skills-character>
      <button type="button" class="btn btn-dark" v-on:click="createCharacter">
        Create
      </button>
    </form>
  </div>
</template>
 
<script>
import api from "../services/api";
import SkillsCharacter from "../components/skillsCharacter.vue";
export default {
  name: "createCharacter",
  data() {
    return {
      classChoose: "",
      character: {
        name: "",
        class: "",
      },
    };
  },
  beforeRouteLeave(to, from, next) {
    this.remove(document.getElementById("app").classList);
    next();
  },
  components: {
    SkillsCharacter,
  },
  methods: {
    createCharacter() {
      if (this.character.class != "") {
        if (this.character.name != "") {
          let data = {
            ClassName: this.character.class,
            Name: this.character.name,
          };
          api.characterApi
            .create(data)
            .then((result) => {
              if (result) {
                this.remove(document.getElementById("app").classList);
                this.$router.push({ name: "Account" });
              }
            });
        } else {
          alert("choose a name for ur character");
        }
      } else {
        alert("choose a class for ur character");
      }
    },
    changeSelect(event) {
      var element = document.getElementById("app");
      this.classChoose = event.target.value;
      switch (this.classChoose) {
        case "Warrior":
          this.remove(element.classList);
          element.classList.add("warrior");
          break;
        case "Shaman":
          this.remove(element.classList);
          element.classList.add("shaman");
          break;
        case "Wizard":
          this.remove(element.classList);
          element.classList.add("wizard");
          break;
        default:
          this.remove(element.classList);
          break;
      }
    },
    remove(classList) {
      while (classList.length > 0) {
        classList.remove(classList.item(0));
      }
    },
  },
};
</script>
<style scoped>
label {
  width: 100px;
}
.img-class {
  width: 5vw;
}
.img-class > img {
  width: 100%;
}
</style>