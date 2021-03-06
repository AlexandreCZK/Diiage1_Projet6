<template>
  <tr>
    <th
      v-bind:style="
        isConnected ? { backgroundColor: 'green' } : { backgroundColor: 'red' }
      "
      scope="row"
      colspan="3"
    >
      {{ user.firstName + " " + user.lastName }}
    </th>
    <th colspan="1">
      <div class="float-right btn btn-danger" @click="deleteFriend(user.id)">
        Delete
      </div>
    </th>
  </tr>
</template>
<script>
import api from "../services/api";
export default {
  props: {
    user: {
      type: Object,
      required: true,
    },
    isConnected: {
      type: Boolean,
      required: true,
    },
  },
  methods: {
    deleteFriend(id) {
      var res = confirm(
        "Do you reality want to remove " +
          this.user.firstName +
          " " +
          this.user.lastName +
          " at your list ?"
      );
      if (!res) {
        return;
      }
      api.userFriendApi.delete(id)
      .then(() => {
        alert("User delete");
        document.location.reload();
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