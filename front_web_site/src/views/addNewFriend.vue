<template>
  <div>
    <h1 class="text-light">Search Friend</h1>
    <div class="text-center">
      <label class="text-light">Add friend</label>
      <div class="row">
        <div class="col-4"></div>
        <input
          type="email"
          class="form-control col-4 text-center"
          aria-describedby="emailHelp"
          placeholder="Enter email"
          v-model="mail"
        />
      </div>
      <div class="btn btn-primary mb-3 mt-3" @click="AddFriend()">Add</div>
      <div class="btn btn-dark mb-3 mt-3" @click="CancelAddFriend()">
        Cancel
      </div>
    </div>
  </div>
</template>
 
<script>
import api from '../services/api'
export default {
  data(){
    return {
      mail: ""
    }
  },
  methods: {
    AddFriend() {
      let data = {
        "mail": this.mail
      };
      api.userFriendApi.create(data)
      .then(() => {
        this.$router.push({ name: "Account" });
      });
    },
    CancelAddFriend() {
      this.$router.push({ name: "Account" });
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