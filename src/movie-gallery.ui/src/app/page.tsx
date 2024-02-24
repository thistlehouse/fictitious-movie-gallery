import CardsWrapper from '@/app/ui/movies/cards';
import styles from '@/app/ui/home.module.css';
import Search from '@/app/ui/movies/search';

export default async function Home({
  searchParams }: {
    searchParams?: {
      filter: string,
    }
  }) {

  const filter = searchParams?.filter || '';

  return (
    <main className={styles.categorySection}>
      <header className="mb-20 mt-20">
        <div className="flex justify-center w-full mt-4 gap-2 md:mt-8">
          <Search placeholder="Search movies..." />
        </div>
      </header>
      <section>
        <CardsWrapper query={filter} />
      </section>
    </main>
  );
}
