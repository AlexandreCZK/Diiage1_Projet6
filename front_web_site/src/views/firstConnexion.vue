<template>
    <div>
        <!-- change name file for createAnAccount -->
        <h1 class="text-light">Create a account</h1>
        <form>
            <div class="form-group">
                <label class="text-light" for="firstName">FirstName:</label>
                <input type="text" id="firstName" v-model="user.firstName" />
            </div>
            <div class="form-group">
                <label class="text-light" for="lastName">LastName:</label>
                <input type="text" id="lastName" v-model="user.lastName" />
            </div>
            <div class="form-group">
                <label class="text-light" for="email">Email:</label>
                <input type="text" id="email" v-model="user.mail" />
            </div>
            <div class="form-group">
                <label class="text-light" for="password">Password:</label>
                <input type="password" id="password" name="motdepasse" v-model="user.password" />
            </div>
            <div class="form-group">
                <label class="text-light" for="confirmPassword">Confirm Password:</label>
                <input type="password"
                       id="confirmPassword"
                       v-model="user.confirmPassword" />
            </div>
            <div class="form-group">
                <label class="text-light" for="birthDate">Birth Date:</label>
                <input type="date" id="birthDate" v-model="user.birthDate" />
            </div>
            <button type="button" class="btn btn-dark" v-on:click="createAccount">
                Create Account
            </button>
        </form>
    </div>
</template>

<script>
import api from "../services/api";
export default {
  name: "createAccount",
  data() {
    return {
      user: {
        mail: "",
        firstName: "",
        lastName: "",
        birthDate: "",
        password: "",
        confirmPassword: "",
      },
    };
  },

  components: {},
  methods: {
    validEmail(){
      var emailReg = new RegExp(/^([\w-.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})/i);
      return emailReg.test(this.user.mail);
    },
    validPassword(password){
      if(password != ""){
        var minSize = new RegExp(/^(.{8,})/);
        var minOneChiffre = new RegExp(/^(?=.*\d)/);
        var minOneLowerCase = new RegExp(/^(?=.*[a-z])/);
        var minOneUpperCase = new RegExp(/^(?=.*[A-Z])/);
        var err = "Your password must be : ";
        if(!minSize.test(password)){
          err += "8 char or more. "
          // alert("Your password must be 8 char or more");
        }
        if(!minOneChiffre.test(password)){
          err += "with minimum 1 number. "
          // alert("Your password must be with minimum 1 number");
        }
        if(!minOneLowerCase.test(password)){
          err += "with minimum one lower case. "
          // alert("Your password must be with minimum one lower case");
        }
        if(!minOneUpperCase.test(password)){
          err += "with minimum one upper case."
          // alert("Your password must be with minimum one upper case");
        }
        if(err != "Your password must be : "){
          alert(err);
          return false;
        }
        else{
          return true;
        }
      }
      return false;
    },
    createAccount() {
      if (
        this.user.mail != "" &&
        this.user.firstName != "" &&
        this.user.lastName != "" &&
        this.user.birthDate != "" &&
        this.user.password != "" &&
        this.user.confirmPassword != ""
      ) {
        if(!this.validPassword(this.user.password)){
          return;
        }
        if (!this.validEmail()){
          alert("Email no valid");
        }
        else if (this.user.password == this.user.confirmPassword) {
          api.authApi
            .signUp(
              this.user.mail,
              this.user.firstName,
              this.user.lastName,
              this.user.birthDate,
              this.user.password,
              this.user.confirmPassword
            )
            .then((result) => {
              if (result) {
                alert("Compte créé");
                this.$router.push({ name: "Authentification" });
              }
            });
        } else {
          //Le mdp and confirm mdp must be same
          alert("password and confirm password must be same");
        }
      } else {
        //all field must be full
        alert("all field must be full");
      }
    }
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