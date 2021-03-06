<template>
  <div>
    <h1>Reset password</h1>
    <form>
      <div class="form-group">
        <label class="text-primary" for="email">Email</label>
        <input type="text" id="email" v-model="user.mail" />
      </div>
      <div class="form-group">
        <label class="text-primary" for="password">Password</label>
        <input type="password" id="password" v-model="user.password" />
      </div>
      <div class="form-group">
        <label class="text-primary" for="newPassword">NewPassword</label>
        <input type="password" id="newPassword" v-model="user.newPassword" />
      </div>
      <button
        type="button"
        class="btn btn-primary"
        v-on:click="sendPasswordResetRequest"
      >
        Send password reset request
      </button>
    </form>
  </div>
</template>
 
<script>
import api from "../services/api";
export default {
  name: "sendPasswordResetRequest",
  data() {
    return {
      user: {
        mail: "",
        password: "",
        newPassword: "",
      },
    };
  },

  components: {},
  methods: {
    sendPasswordResetRequest() {
      api.authApi
        .resetPassword(
          this.user.mail,
          this.user.password,
          this.user.newPassword
        )
        .then((result) => {
          if (result) {
            alert("Password modify");
          }
        });
    },
  },
};
</script>
<style>
.question-previews .list-group-item {
  cursor: pointer;
}
</style>