<template>
  <div>
    <h1 class="text-light text-center">Create a new game</h1>
    <div class="btn btn-dark mb-3 mt-3 float-left" @click="SinglePlayer()">
      Single player
    </div>
    <div class="btn btn-dark mb-3 mt-3 float-right" @click="MultiPlayer()">
      Multi players
    </div>
  </div>
</template>
 
<script>
export default {
  methods: {
    SinglePlayer() {
      // add method for add friend
      this.$router.push({ name: "CreateNewGameSinglePlayer" });
    },
    MultiPlayer() {
      this.$router.push({ name: "CreateNewGameMultiPlayer" });
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