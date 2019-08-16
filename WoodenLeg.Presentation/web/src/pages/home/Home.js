import React from "react";
import NavBar from "../../components/navbar";
import Footer from "../../components/footer";

export default function Home() {
  return (
    <div>
      <NavBar />
      <h1>This is the home page</h1>
      <footer>
        <Footer />
      </footer>
    </div>
  );
}
