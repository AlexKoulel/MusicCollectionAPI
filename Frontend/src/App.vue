<script setup>
</script>

<template>
  <div v-for="album in albums" :key="album.id">
    <ul class="album-item">
      <span class="album-description">
        {{ album.title }} - {{ album.artist }} - {{ album.genre }} - {{ album.releaseDate }} - Owned in {{ album.format
        }}
      </span>
      <button @click="deleteAlbum(album.id)">Delete Album</button>
    </ul>

  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      albums: [],
    };
  },
  created() {
    this.getAlbums();
  },
  methods: {
    async getAlbums() {
      try {
        const response = await axios.get('http://localhost:5000/albums');
        console.log(response.data);
        this.albums = response.data;
      } catch (error) {
        console.error('Could not fetch albums', error);
      }
    },
    async deleteAlbum(id) {
      try {
        await axios.delete(`http://localhost:5000/albums/${id}`);
        this.albums = this.albums.filter(album => album.id !== id);
      } catch (error) {
        console.error('Could not find album.', error);
      }
    }
  }
}

</script>
