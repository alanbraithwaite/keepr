<template>
  <div class="">
    <div class=" ">
      <h1>Your Keeps</h1>
      <div class="row col-12 d-flex justify-content-center">
        <i data-toggle="tooltip" data-placement="bottom" title="New Keep" @click="showAddKeepForm = !showAddKeepForm"
          class="col-2 far fa-plus-square fa-2x"></i>
        <form @submit.prevent="addKeep" v-if="showAddKeepForm">
          <input type="text" placeholder="Name" v-model="newKeep.name" required>
          <input type="text" placeholder="Image Link" v-model="newKeep.img">
          <input type="textarea" placeholder="Description" v-model="newKeep.description" required>
          <input type="checkbox" v-model="isPrivate" title="Private">
          <button data-toggle="tooltip" data-placement="bottom" title="addKeep" type="submit"><i class="fas fa-plus"></i></button>
        </form>
      </div>

      <div class="row">
        <div class="row col d-flex justify-content-center" v-for="keep in userkeeps" :key="keep.id">
          <div class=" card">
            <img :src="keep.img" height="150" width="200">
            <span class="name">{{keep.name}}</span>
            <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
            <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
            <div> <button @click="deleteKeep(keep.id)"><i class=" fas fa-trash"></i></button>
              <router-link :to="{name: 'currentkeep', params: {keepId: keep.id}}">
                <h4>VIEW</h4>
              </router-link>
              <select v-model="selectedVault" name="Add to Vault">
                <option selected>Add to Vault</option>
                <option @click="addKeepToVault(keep.id,vault.id)" v-for="vault in vaults" :key="vault.name" class="custom-select"
                  :value="vault.id">{{vault.name}}</option>
              </select>

              <!-- <div class="dropdown">
                <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false">
                  <i class="fas fa-plus"></i>Vault
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a class="dropdown-item" href="" v-for="vault in vaults" :key="vault.name"></a>>{{vault.name}}</a>
                </div>
              </div> -->
              <!-- <button class="" @click="getKeep(keep.id)">View</button> -->

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

  export default {
    name: 'keeps',
    data() {

      return {
        selectedVault: 'Add to Vault',

        showAddKeepForm: false,
        newKeep: {
          name: '',
          description: '',
          img: '',
          view: 0,
          keeps: 0,
          isPrivate: false,
          shares: 0,

        }
      }
    },
    computed: {
      userkeeps() {
        return this.$store.state.userkeeps;
        debugger
      },
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
      addKeepToVault(keepId, vaultId) {
        // creats a keyvaule pair
        let payload = {
          keepId,
          vaultId
        }
        debugger
        this.$store.dispatch('addKeepToVault', payload)
      },

      addKeep() {
        this.$store.dispatch('addKeep', this.newKeep)
        // if (img == "") {
        //   img = 'https://s3.amazonaws.com/images.gearjunkie.com/uploads/2018/05/nanga-parbat.jpg'
        // }
        this.newKeep = {
          name: '',
          description: '',
          img: '',
          view: 0,
          keeps: 0,
          isPrivate: 0,
          shares: 0
        }
      },

      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId)
      }
    },
    props: ["keepId"]

  }

</script>

<style>


</style>