<template>
  <div id="app">
    <nav class="navbar navbar-expand-md navbar-dark bg-dark shadow">
      <label class="navbar-brand text-light">Dungeon Crawler</label>
      <ul class="navbar-nav mr-auto">
        <li class="nav-item active">
          <a class="nav-link" href="/">Home</a>
        </li>
      </ul>
      <!-- <button class="my-2 my-lg-0" v-on:click="account">
          <i class="far fa-user-circle fa-2x text-light"></i>
        </button> -->
      <div class="dropdownAccount" v-if="token == '' || token == null">
        <b-dropdown text="My account">
          <b-dropdown-item @click="redirect('login')">Login</b-dropdown-item>
          <b-dropdown-item @click="redirect('signIn')" href="#/firstConnexion"
            >SignIn</b-dropdown-item
          >
        </b-dropdown>
      </div>
      <div class="dropdownAccount" v-else>
        <b-dropdown text="My account">
          <b-dropdown-item @click="redirect('account')"
            >My Account</b-dropdown-item
          >
          <b-dropdown-item @click="redirect('signOut')"
            >SignOut</b-dropdown-item
          >
        </b-dropdown>
      </div>
    </nav>
    <div class="text-danger font-weight-bold text-center h3" id="error"></div>
    <main role="main" class="container mt-4">
      <router-view />
    </main>
  </div>
</template>
<script>
import api from "../src/services/api";
export default {
  name: "App",
  data() {
    return {
      token: this.$cookies.get("token"),
    };
  },
  mounted() {
    this.$root.$on("token-refresh", (token) => {
      this.$cookies.set("token", token);
      this.token = this.$cookies.get("token");
    });
  },
  components: {},
  methods: {
    redirect(path) {
      switch (path) {
        case "login":
          this.$router.push({ name: "Authentification" });
          break;
        case "signIn":
          this.$router.push({ name: "FirstConnexion" });
          break;
        case "account":
          this.$router.push({ name: "Account" });
          break;
        case "signOut":
          api.authApi.signOut().then(() => {
            this.$root.$emit("token-refresh", "");
            if (this.$route.name != "Home") {
              this.$router.push({ name: "Home" });
            }
          });
          break;
      }
    },
  },
};
</script>
<style>
 #app {
  background-attachment: fixed;
  min-height: 100vh;
  background-repeat: no-repeat;
  background-image: url("../src/assets/background.jpg") !important;
}

#app.warrior {
  background-image: url("../src/assets/warrior.jpg") !important;
}
#app.shaman {
  background-image: url("../src/assets/shaman.jpg") !important;
}
#app.wizard {
  background-image: url("../src/assets/wizzard2.jpg") !important;
}
button {
  all: unset;
  cursor: pointer;
}
.dropdownAccount {
  margin-right: 2vw;
}
</style>  