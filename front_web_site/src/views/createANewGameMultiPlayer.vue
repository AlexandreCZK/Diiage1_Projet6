<template>
  <div>
    <h1 class="text-light text-center">Create a new game single player</h1>
    <div class="row mt-5">
      <CardCharacter
        v-for="character in characters"
        :key="character.id"
        :character="character"
        :isPlay="true"
        :isMultiplayer="true"
      >
      </CardCharacter>
    </div>
  </div>
</template>
 
<script>
import api from "../services/api";
import CardCharacter from "../components/cardCharacter.vue";
export default {
  // données en dur à retirer plus tard
  data() {
    return {
      characters: [],
    };
  },
  mounted() {
    api.characterApi.get().then((result) => {
      this.characters = result;
    });
  },
  components: {
    CardCharacter,
  },
  methods: {
    createGame() {
      api.gameApi.createAGame(true).then(() => {});
    },
  },
};
</script>
<style>
h1 {
  margin-left: auto;
  margin-right: auto;
  width: 8em;
}
</style>