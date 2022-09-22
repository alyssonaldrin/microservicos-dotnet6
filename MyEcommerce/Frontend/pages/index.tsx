import type { NextPage } from 'next'
import { Head } from '../components/head'
import styles from '../styles/Home.module.css'

const Home: NextPage = () => {
  return (
    <div className={styles.container}>
      <Head />
    </div>
  )
}

export default Home
