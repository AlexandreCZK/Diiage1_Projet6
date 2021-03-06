import Vue from 'vue'
import App from './App'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import VueCookies from 'vue-cookies'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import '@fortawesome/fontawesome-free/css/all.css'
 
Vue.config.productionTip = false
 
// Install Vue extensions
Vue.use(BootstrapVue);
Vue.use(VueCookies)
Vue.$cookies.config('1d')
 
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')