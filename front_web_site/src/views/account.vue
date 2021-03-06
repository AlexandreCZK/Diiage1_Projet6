<template>
  <div>
    <h1 class="text-light">My account</h1>
    <!-- Page Content -->
    <div class="container">
      <div class="btn btn-dark mb-3" @click="createCharacter()">
        Create a character
      </div>
      <div class="btn btn-dark mb-3" @click="createNewGame()">
        Create a new game
      </div>
      <div class="row">
        <div class="col-lg-8">
          <div class="row">
            <CardCharacter
              v-for="character in characters"
              :key="character.id"
              :character="character"
              :isPlay="false"
            >
            </CardCharacter>
          </div>
          <!-- /.row -->
        </div>
        <!-- /.col-lg-8 -->
        <div class="table-responsive col-lg-4 col-sm-12 float-right">
          <table class="table text-light">
            <thead>
              <tr>
                <th scope="col" colspan="12">
                  <h1><u>Friends</u></h1>
                </th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th scope="row" colspan="1">
                  <div>Friend online</div>
                </th>
                <th scope="col" colspan="1">
                  <div
                    class="float-right btn btn-secondary"
                    @click="friendAdd()"
                  >
                    Add
                  </div>
                </th>
              </tr>
              <FriendInformation
                v-for="user in friends"
                :key="user.id"
                :user="user"
                :isConnected="user.isConnected"
              >
              </FriendInformation>
            </tbody>
          </table>
        </div>
      </div>
      <!-- /.row -->
    </div>
    <!-- /.container -->
  </div>
</template>
 
<script>
import api from "../services/api";
import CardCharacter from "../components/cardCharacter.vue";
import FriendInformation from "../components/friendInformation.vue";
export default {
  name: "Account",
  components: {
    CardCharacter,
    FriendInformation,
  },
  //données en dur à retirer
  data() {
    return {
      characters: [],
      friends: [],
    };
  },
  mounted: function () {
    api.characterApi.get().then((result) => {
      if (result.length == 0) {
        alert("create a character");
        this.$router.push({ name: "CreateCharacter" });
      } else {
        this.characters = result;
      }
    });
    api.userFriendApi.get().then((result) => {
      this.friends = result;
    });
  },
  methods: {
    createNewGame() {
      this.$router.push({ name: "CreateNewGame" });
    },
    friendAdd() {
      this.$router.push({ name: "AddNewFriend" });
    },
    createCharacter() {
      this.$router.push({ name: "CreateCharacter" });
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