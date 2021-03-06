import Vue from 'vue'
import Router from 'vue-router'
import HomePage from '@/views/home'
import FirstConnexionPage from '@/views/firstConnexion'
import AuthentificationPage from '@/views/authentification'
import ResetPasswordRequest from '@/views/resetPasswordRequest'
import Account from '@/views/account'
import CreateCharacter from '@/views/createACharacter'
import ModifySkills from '@/views/modifySkills'
import AddNewFriend from '@/views/addNewFriend'
import CreateNewGame from '@/views/createANewGame'
import CreateNewGameSinglePlayer from '@/views/createANewGameSinglePlayer'
import CreateNewGameMultiPlayer from '@/views/createANewGameMultiPlayer'
import SinglePlayerGame from '@/views/singlePlayerGame'

Vue.use(Router)
export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: HomePage
    },
    {
      path: '/firstConnexion',
      name: 'FirstConnexion',
      component: FirstConnexionPage
    },
    {
      path: '/authentification',
      name: 'Authentification',
      component: AuthentificationPage
    },
    {
      path: '/resetPasswordRequest',
      name: 'ResetPasswordRequest',
      component: ResetPasswordRequest
    },
    {
      path: '/account',
      name: 'Account',
      component: Account
    },
    {
      path: '/createCharacter',
      name: 'CreateCharacter',
      component: CreateCharacter
    },
    {
      path: '/modifySkills',
      name: 'ModifySkills',
      component: ModifySkills
    },
    {
      path: '/addNewFriend',
      name: 'AddNewFriend',
      component: AddNewFriend
    },
    {
      path: '/createNewGame',
      name: 'CreateNewGame',
      component: CreateNewGame
    },
    {
      path: '/createNewGameSinglePlayer',
      name: 'CreateNewGameSinglePlayer',
      component: CreateNewGameSinglePlayer
    },
    {
      path: '/createNewGameMultiPlayer',
      name: 'CreateNewGameMultiPlayer',
      component: CreateNewGameMultiPlayer
    },
    {
      path: '/singlePlayerGame',
      name: 'SinglePlayerGame',
      component: SinglePlayerGame
    }
  ]
})