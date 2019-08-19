import React from "react";
import NavBar from "../../components/navbar";
import Footer from "../../components/footer";
import Recent from "../../components/recents"

export default function Home() {
  return (
    <div>
      <NavBar />
      <h1>This is the home page</h1>
      <Recent />
      <Footer />
    </div>
  );
}
