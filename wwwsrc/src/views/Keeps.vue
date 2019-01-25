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
          <input type="checkbox" v-model="newKeep.isPrivate" title="Private">
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
              <select v-model="selectedVault">
                <option v-for="vault in vaults" class="custom-select" :value="vault.id">{{vault.name}}</option>
              </select>
              <button type="button" @click.prevent="addKeepToVault(keep.id)">Add to Vault</button>
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

    mounted() {
      this.$store.dispatch('getUserKeeps');

    },
    methods: {


      addKeepToVault(keepId) {
        // creats a keyvaule pair

        let payload =
        {
          keepId: keepId,
          vaultId: this.selectedVault
        }
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