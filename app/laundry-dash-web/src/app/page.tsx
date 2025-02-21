import Link from 'next/link';
import { buttonVariants } from "@/components/ui/button"
import type { NextPage } from 'next';

// Define the Home component as a functional component using TypeScript
const Home: NextPage = () => {
  return (
    // Outer div centers the content vertically and horizontally using Tailwind utilities
    <div className="min-h-screen flex flex-col items-center justify-center bg-base-100 p-4">
      {/* Header: Displays the application title */}
      <header className="mb-12">
        <h1 className="text-5xl font-bold text-center">LaundryDasher</h1>
      </header>

      {/* Main content: Introduction text and sign in/up buttons */}
      <main className="flex flex-col items-center gap-8">
        {/* Introductory text */}
        <p className="text-xl text-center max-w-md">
          Welcome to LaundryDasher! Please sign in or sign up to continue.
        </p>

        {/* Container for the sign in and sign up buttons with spacing between them */}
        <div className="flex space-x-4">
          {/* Button for signing in; routes to /signin */}
          <Link className={buttonVariants()} href="/login">
            Sign In
          </Link>
          {/* Button for signing up; routes to /signup */}
          <Link className={buttonVariants()} href="/signup">
            Sign Up
          </Link>
        </div>
      </main>

      {/* Footer: Displays a simple copyright */}
      <footer className="mt-12">
        <p className="text-sm text-center">
          LaundryDasher © {new Date().getFullYear()}
        </p>
      </footer>
    </div>
  );
};

export default Home;
