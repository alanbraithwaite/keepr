import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publickeeps: [],
    userkeeps: [],
    vaults: [],
    vaultkeeps: [],
    activevault: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, publickeeps) {
      state.publickeeps = publickeeps
    },
    setUserKeeps(state, userkeeps) {
      state.userkeeps = userkeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps
    },
    setActiveVault(state, activevault) {
      state.activevault = activevault
    }
  },
  actions: {

    // AUTH STUFF
    //  login / register / authenticate / logout
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          console.log(res.data)
          commit('setUser', {})
          console.log('user logged out')
          router.push({ name: 'home' })
        })
        .catch(err => console.log('Cannot Logout'))
    },

    // KEEP STUFF

    getPublicKeeps({ commit, dispatch }) {
      api.get('keeps/')
        .then(res => {
          console.log("Keeps", res.data)
          commit("setPublicKeeps", res.data)
          router.push({ name: 'home' })
        })
        .catch(err => console.log('Cannot get public keeps'))
    },



    incrementKeepView({ commit, dispatch }, keep) {
      keep.views++
      api.put('keeps/' + keep.id, keep)
        .then(res => {
          // dispatch("getUserKeeps")
        })
        .catch(err => console.log('Cannot increment keep view'))
    },


    getUserKeeps({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          console.log("Keeps", res.data)
          commit("setUserKeeps", res.data)
          router.push({ name: 'keeps' })
        })
        .catch(err => console.log('Cannot get public keeps'))
    },

    addKeep({ commit, dispatch }, newKeep) {
      api.post('keeps/', newKeep)
        .then(res => {
          dispatch("getUserKeeps")
        })
        .catch(err => console.log('Cannot get public keeps'))
    },

    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch("getUserKeeps")
        })
        .catch(err => console.log('Cannot delete keeps'))
    },


    // VAULT STUFF
    getVaults({ commit, dispatch }) {
      api.get('vaults/')
        .then(res => {
          console.log("vaults", res.data)
          commit("setVaults", res.data)
          // router.push({ name: 'vaults' })
        })
        .catch(err => console.log('Cannot get Vaults'))
    },

    addVault({ commit, dispatch }, newVault) {
      api.post('vaults/', newVault)
        .then(newVault => {
          dispatch('getVaults')
        })
    },

    deleteVault({ commit, dispatch }, vaultId) {

      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
    },

    // VAULTKEEP STUFF
    getVaultKeeps({ commit, dispatch }, vault) {
      api.get('vaultkeeps/' + vault)
        .then(res => {
          console.log("VaultKeeps", res.data)
          commit("setVaultKeeps", res.data)
          commit("setActiveVault", vault)

          // router.push({ name: 'vault' })
        })
        .catch(err => console.log('Cannot get keeps by Vault'))
    },

    removeFromVault({ commit, dispatch }, payload) {
      api.put('vaultkeeps/', payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
          // router.push({ name: 'vault' })
        })
        .catch(err => console.log('Cannot remove Keep from Vault'))
    },

    addKeepToVault({ commit, dispatch }, payload) {
      api.post('vaultkeeps/', payload)
        .then(res => {
          console.log("Add Keep to Vault", res.data)
          dispatch('getVaultKeeps', payload.vaultId)
        })
    }


  }
})