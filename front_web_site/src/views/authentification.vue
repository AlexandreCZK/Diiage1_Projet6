<template>
  <div class="auth">
    <h1 class="text-light">Dungeon Crawler</h1>
    <form class="pt-5">
      <div class="form-group">
        <label class="text-light" for="mail">Email:</label>
        <input type="text" id="mail" v-model="user.mail" />
      </div>
      <div class="form-group">
        <label class="text-light" for="password">Password:</label>
        <input type="password" id="password" v-model="user.password" />
      </div>
      <button type="button" class="btn btn-dark" v-on:click="connection">
        Connection
      </button>
    </form>
  </div>
</template>
 
<script>
import api from "../services/api";
export default {
  name: "connection",
  data() {
    return {
      user: {
        mail: "",
        password: "",
      },
    };
  },

  components: {},
  methods: {
    connection() {
      if (this.user.mail == "" || this.user.password == "") {
        alert("Email and Password must be full");
      } else {
        api.authApi
          .login(this.user.mail, this.user.password)
          .then((result) => {
            this.$root.$emit("token-refresh", result);
            this.$router.push({ name: "Account" });
          });
      }
    },
  },
};
</script>
<style scoped>
.auth {
  margin: 0 auto;
  width: 20vw;
}
.form-group > label {
  width: 100px;
}
</style>